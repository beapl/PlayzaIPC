using Microcharts;
using SkiaSharp;
using Playza.Services;

namespace Playza.Views {

public partial class ParentalControlPage : ContentPage
{
        private readonly UsageTracker _usageTracker = new UsageTracker();

        public ParentalControlPage()
	{
		InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Aqui era suposto colocar o gráfico de atividade but it's not working
        }
    
    private async void OnDefParClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalSettingsPage");
    }

    private async void OnRelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RelatorioPage");
    }
    private async void OnAjudaClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MenuPage");
    }
}
}