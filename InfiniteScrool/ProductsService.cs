using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;

namespace InfiniteScrool
{
    public class ProductsService
    {
        private string baseUrl = "https://dummyjson.com/";
        public async Task<ObservableCollection<Product>> GetProductsAsync(int limit = 10, int skip = 0)
        {
            var productsList = new ObservableCollection<Product>();

            var client = new RestClient(baseUrl);

            var request = new RestRequest($"products?limit={limit}&skip={skip}", Method.Get);

            var query = await client.GetAsync(request);

            var products = JsonConvert.DeserializeObject<Products>(query.Content);

            productsList = products.ProductsList;

            return productsList;
        }
    }
}
