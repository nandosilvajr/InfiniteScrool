using Microsoft.AspNetCore.Components.WebView.Maui;
using InfiniteScrool.Data;

namespace InfiniteScrool;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddSingleton<ProductsService>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

        return builder.Build();
	}
}
