using Playza.Models;
using Playza.Services;

namespace Playza.Views;

public partial class RelatorioPage : ContentPage
{
    public RelatorioPage()
    {
        InitializeComponent();
        var report = GameSessionManager.Instance.CurrentReport;

        BindingContext = new
        {
            TotalTimeDisplay = $"Tempo Total: {report.TotalTime:mm\\:ss}",
            MiniGameReports = report.MiniGameReports.Select(m => new
            {
                m.GameName,
                TimeTakenDisplay = $"Tempo: {m.TimeTaken:mm\\:ss}",
                StartEndDisplay = $"Início: {m.StartTime:HH:mm:ss} → Fim: {m.EndTime:HH:mm:ss}"
            }).ToList()
        };
    }
}
