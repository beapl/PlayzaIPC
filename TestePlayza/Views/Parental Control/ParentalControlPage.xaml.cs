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

            // Obt�m os dados de tempo de uso da classe UsageTracker
            var usageData = await _usageTracker.GetUsageData();

            // Converte os dados de uso para o formato de gr�fico
            var entries = usageData.Select(data => new ChartEntry((float)data.Value)
            {
                Label = data.Key,
                ValueLabel = $"{data.Value} min",
                Color = SKColor.Parse("#ff0000")
            }).ToList();

            // Cria o gr�fico de barras
            var chart = new BarChart() // Ou outro tipo de gr�fico, como LineChart
            {
                Entries = entries, // Adiciona as entradas ao gr�fico
                LabelTextSize = 30  // Ajuste do tamanho da legenda
            };

            // Exibe o gr�fico na p�gina
            chartView.Chart = chart;
        }
    
    private async void OnDefParClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalSettingsPage");
    }

    private async void OnRelatorioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalControlPage");
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