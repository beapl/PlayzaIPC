namespace Playza.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void OnSairClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MenuPage");
    }
}
