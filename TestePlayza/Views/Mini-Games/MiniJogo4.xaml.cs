using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Playza.Views;

public partial class MiniJogo4 : ContentPage
{
    private Image _selectedTrash = null;
    private string OriginPage;
    public MiniJogo4() : this("MiniGamesPage")
    {
    }
    public MiniJogo4(string origin)
    {
        InitializeComponent();
        OriginPage = origin;
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
                ShowFinalPanel();
            }
        }
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
        PauseMenu.IsVisible = true;
    }

    private void OnResumeClicked(object sender, EventArgs e)
    {
        PauseMenu.IsVisible = false;
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        if (OriginPage == "JourneyPage")
        {
            await Shell.Current.GoToAsync("JourneyPage");
        }
        else
        {
            await Navigation.PopAsync();
        }
    }

    private void ShowFinalPanel()
    {
        if (OriginPage == "JourneyPage")
        {
            // Alterar textos
            FinalTitleLabel.Text = "Acabaste o nível!";
            FinalMessageLabel.Text = "Parabéns! Reciclaste tudo corretamente!\nAgora podes descansar";

            // Esconder botão de reiniciar, mostrar botão para tela de desenho
            RestartButton.IsVisible = false;
            DrawScreenButton.IsVisible = true;
        }
        else
        {
            FinalTitleLabel.Text = "🎉 Fim do Jogo!";
            FinalMessageLabel.Text = "Parabéns! Reciclaste tudo corretamente!";
            RestartButton.IsVisible = true;
            DrawScreenButton.IsVisible = false;
        }

        FinalOverlay.IsVisible = true;
    }

    private void OnRestartClicked(object sender, EventArgs e)
    {
        FinalOverlay.IsVisible = false;
        FeedbackLabel.Text = "";

        // Reexibir todos os lixos
        GlassBottle.IsVisible = true;
        PlasticBottle.IsVisible = true;
        Paper.IsVisible = true;
        TinCan.IsVisible = true;
    }

    private async void OnCanvasClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CanvasPage");
    }
}