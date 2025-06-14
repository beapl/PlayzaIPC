namespace Playza.Views;

public partial class MiniGamesPage : ContentPage
{
    public MiniGamesPage()
    {
        InitializeComponent();
        BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
    }

    private async void OnMiniGame1Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo1");
    }

    private async void OnMiniGame2Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo2");
    }

    private async void OnMiniGame3Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo3");
    }

    private async void OnMiniGame4Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo4");
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MenuPage");
    }

}