namespace Playza.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("GamePage");
    }

    private async void OnMiniGameClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniGamesPage");
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
