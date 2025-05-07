namespace Playza.Views
{
    public partial class Register1Page : ContentPage
    {
        public Register1Page()
        {
            InitializeComponent();
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Register2Page");
        }
    }
}