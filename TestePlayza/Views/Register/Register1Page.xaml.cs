using Playza.Services;
using Playza.Models;
using System.Text.Json;

namespace Playza.Views
{
    public partial class Register1Page : ContentPage
    {

        private readonly UserDatabase _userDatabase;
        private string _name;
        private string _username;
        private string _password;
    public Register1Page(string name, string username, string password)
        {
            InitializeComponent();
            BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");

        _name = name;
            _username = username;
            _password = password;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            _userDatabase = new UserDatabase(dbPath);
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var selectedOptions = new List<string>();

            if (PortuguesCheck.IsChecked) selectedOptions.Add("Português");
            if (MatematicaCheck.IsChecked) selectedOptions.Add("Matemática");
            if (EstudoCheck.IsChecked) selectedOptions.Add("Estudo do Meio");
            if (ArtisticaCheck.IsChecked) selectedOptions.Add("Educação Artística");
            if (InglesCheck.IsChecked) selectedOptions.Add("Inglês");
            if (NenhumaCheck.IsChecked) selectedOptions.Add("Nenhuma");

            string selectedOptionsJson = JsonSerializer.Serialize(selectedOptions);

            var user = new User
            {
                Name = _name,
                Username = _username,
                Password = _password,
                SelectedOptionsJson = selectedOptionsJson
            };

            await _userDatabase.SaveUserAsync(user);

            await DisplayAlert("Sucesso", "Conta criada!", "OK");
            await Shell.Current.GoToAsync("Register2Page");
        }
    }
}