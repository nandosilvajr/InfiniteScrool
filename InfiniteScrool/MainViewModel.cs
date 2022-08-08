using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteScrool
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        Products _products;

        [ObservableProperty]
        ObservableCollection<Product> _productsList;

        [ObservableProperty]
        bool _isLoading;

        [RelayCommand]
        public void LoadMoreData()
        {
            if (IsLoading) return;

            if (_productsList.Count > 0)
            {

                IsLoading = true;

             
                var response = Task
                    .Run(async () => await _productsService
                    .GetProductsAsync(skip: _productsList.Count));

                foreach (var item in response.Result)
                {
                    _productsList.Add(item);
                }
                IsLoading = false;
            }
        }


        ProductsService _productsService;
        public MainViewModel(ProductsService productsService)
        {

            _productsService = productsService;

            GetData();

        }

        private void GetData()
        {

            var response = Task
                .Run(async () => await _productsService
                .GetProductsAsync());

            _productsList = new(response.Result);

        }
    }
}
