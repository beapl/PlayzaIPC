namespace Playza.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();
        BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
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
        //await Shell.Current.GoToAsync("ParentalControlPage");
        if (!PreferencesHelper.HasPin())
        {
            //configurar PIN
            var newPin = await DisplayPromptAsync("Configurar PIN", "Digite um PIN (mínimo 4 dígitos):", maxLength: 6, keyboard: Keyboard.Numeric);
            if (string.IsNullOrWhiteSpace(newPin) || newPin.Length < 4)
            {
                await DisplayAlert("Erro", "PIN inválido. Operação cancelada.", "OK");
                return;
            }
            PreferencesHelper.SetPin(newPin);
        }
        else
        {
            //já tem PIN
            var enteredPin = await DisplayPromptAsync("Digite o seu PIN", "Por favor, informe o seu PIN:", maxLength: 6, keyboard: Keyboard.Numeric);

            if (enteredPin != PreferencesHelper.GetPin())
            {
                await DisplayAlert("Erro", "PIN incorreto.", "OK");
                return;
            }
        }
        await Navigation.PushAsync(new ParentalControlPage());
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
