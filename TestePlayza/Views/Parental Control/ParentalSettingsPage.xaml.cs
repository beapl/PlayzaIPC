namespace Playza.Views;

public partial class ParentalSettingsPage : ContentPage
{
	public ParentalSettingsPage()
	{
		InitializeComponent();
	}

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalControlPage");
    }
}