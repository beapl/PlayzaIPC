using Playza.Services;
using Playza.Utils;

namespace Playza.Views;

public partial class LoginPage : ContentPage
{
    private readonly UserDatabase _userDatabase;
    public LoginPage()
    {
        InitializeComponent();
        BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
        _userDatabase = new UserDatabase(dbPath);
    }

    private async void OnSairClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erro", "Preenche todos os campos.", "OK");
            return;
        }

        var user = await _userDatabase.GetUserByUsernameAndPasswordAsync(username, password);

        if (user != null)
        {
            Session.CurrentUser = user; // Aqui está definido a sessão com o utilizador logged in

       
            await DisplayAlert("Bem-vindo!", $"Olá, {user.Name}!", "OK");
            await Shell.Current.GoToAsync("MenuPage");
        }
        else
        {
            await DisplayAlert("Erro", "Credenciais incorretas.", "OK");
        }
    }
}
    

