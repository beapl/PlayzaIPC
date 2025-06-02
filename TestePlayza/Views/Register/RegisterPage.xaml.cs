using System.Xml.Linq;
using Playza.Models;

namespace Playza.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Erro", "Preenche todos os campos.", "OK");
                return;
            }

            var nextPage = new Register1Page(name, username, password);

            await Navigation.PushAsync(nextPage);
        }
    }
}
