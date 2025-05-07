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

            // Obtém os dados de tempo de uso da classe UsageTracker
            var usageData = await _usageTracker.GetUsageData();

            // Converte os dados de uso para o formato de gráfico
            var entries = usageData.Select(data => new ChartEntry((float)data.Value)
            {
                Label = data.Key,
                ValueLabel = $"{data.Value} min",
                Color = SKColor.Parse("#ff0000")
            }).ToList();

            // Cria o gráfico de barras
            var chart = new BarChart() // Ou outro tipo de gráfico, como LineChart
            {
                Entries = entries, // Adiciona as entradas ao gráfico
                LabelTextSize = 30  // Ajuste do tamanho da legenda
            };

            // Exibe o gráfico na página
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