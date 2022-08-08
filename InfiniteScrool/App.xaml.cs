namespace InfiniteScrool;

public partial class App : Application
{
	public App(MainViewModel vm)
	{
		InitializeComponent();

		MainPage = new MainPage(vm);
	}
}
