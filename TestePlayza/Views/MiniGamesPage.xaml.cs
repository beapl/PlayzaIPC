namespace Playza.Views;

public partial class MiniGamesPage : ContentPage
{
	public MiniGamesPage()
	{
		InitializeComponent();
	}

    private async void OnMiniGame1Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniGame1");
    }

    private async void OnMiniGame2Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniGame2");
    }
}