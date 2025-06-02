namespace Playza.Views
{
    public partial class Register2Page : ContentPage
    {
        public Register2Page()
        {
            InitializeComponent();
            BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MenuPage");
        }
    }
}