using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Playza.Views;

public partial class MiniJogo4 : ContentPage
{
    private Image _selectedTrash = null;

    public MiniJogo4()
    {
        InitializeComponent();
    }

    private void OnTrashTapped(object sender, EventArgs e)
    {
        if (sender is Image img)
        {
            _selectedTrash = img;
            FeedbackLabel.Text = $"Pegaste em: {img.ClassId}";
            FeedbackLabel.TextColor = Colors.Black;
        }
    }

    private void OnContainerTapped(object sender, EventArgs e)
    {
        if (_selectedTrash == null)
        {
            FeedbackLabel.Text = "Escolhe primeiro um lixo!";
            FeedbackLabel.TextColor = Colors.Red;
            return;
        }

        if (sender is Image container)
        {
            if (_selectedTrash.AutomationId == container.AutomationId)
            {
                FeedbackLabel.Text = "Boa! Recolha correta!";
                FeedbackLabel.TextColor = Colors.Green;
                _selectedTrash.IsVisible = false;
            }
            else
            {
                FeedbackLabel.Text = "Ops! Contentor errado.";
                FeedbackLabel.TextColor = Colors.Red;
            }

            _selectedTrash = null;

            if (!GlassBottle.IsVisible &&
                !PlasticBottle.IsVisible &&
                !Paper.IsVisible &&
                !TinCan.IsVisible)
            {
                FeedbackLabel.Text = "Parabéns! Conseguiste Fazer a reciclagem! 🎉";
                FeedbackLabel.TextColor = Colors.DarkGreen;
            }
        }
    }
}