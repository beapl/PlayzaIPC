namespace Playza.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("JourneyPage");
    }

    private async void OnMiniClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniGamesPage");
    }
    private async void OnParentalClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalControlPage");
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
