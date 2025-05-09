using Playza.Services;

namespace Playza.Views;

public partial class LoginPage : ContentPage
{
    private readonly UserDatabase _userDatabase;
    public LoginPage()
    {
        InitializeComponent();
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
            // Aqui podes guardar sessão se quiseres (Ex: Preferences)
            await DisplayAlert("Bem-vindo!", $"Olá, {user.Name}!", "OK");
            await Shell.Current.GoToAsync("MenuPage");
        }
        else
        {
            await DisplayAlert("Erro", "Credenciais incorretas.", "OK");
        }
    }
}
    

