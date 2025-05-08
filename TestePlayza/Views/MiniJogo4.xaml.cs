namespace Playza.Views;

public partial class MiniJogo4 : ContentPage
{
    public MiniJogo4()
    {
        InitializeComponent();
    }

    private void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        if (sender is Image image)
        {
            e.Data.Properties["tipoLixo"] = image.AutomationId;
            e.Data.Text = "lixo"; // necessário para ativar o drag
        }
    }

    private void OnDrop(object sender, DropEventArgs e)
    {
        if (sender is Image contentor &&
            e.Data.Properties.TryGetValue("tipoLixo", out var tipoLixoObj))
        {
            string tipoLixo = tipoLixoObj?.ToString();
            string contentorCor = contentor.AutomationId;

            if (tipoLixo == contentorCor)
            {
                FeedbackLabel.Text = "Acertaste! 😀";
                FeedbackLabel.TextColor = Colors.Green;

                // Encontra e esconde a imagem correta
                var draggedImage = LixosLayout.Children
                    .OfType<Image>()
                    .FirstOrDefault(img => img.AutomationId == tipoLixo && img.IsVisible);

                if (draggedImage != null)
                    draggedImage.IsVisible = false;
            }
            else
            {
                FeedbackLabel.Text = "Erraste 😕";
                FeedbackLabel.TextColor = Colors.Red;
            }
        }
    }
}
