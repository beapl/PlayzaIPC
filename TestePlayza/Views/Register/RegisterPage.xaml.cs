using System.Xml.Linq;
using Playza.Models;

namespace Playza.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {

            var user = new User
            {
                Name = NameEntry.Text,
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            var existing = await App.Database.GetUserByUsernameAsync(user.Username);
                if (existing != null)
                {
                    await DisplayAlert("Erro", "Essa alcunha já existe!", "OK");
                    return;
                }

                await App.Database.SaveUserAsync(user);
                await Shell.Current.GoToAsync("Register1Page");
            }
    }
}
