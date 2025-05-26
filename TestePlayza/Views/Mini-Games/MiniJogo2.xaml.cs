using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Playza.Views;

public partial class MiniJogo2 : ContentPage
{

    int leftCount;
    int rightCount;
    int score = 0;
    int rounds = 0;
    bool isPaused = false;
    Random rand = new Random();
    private string OriginPage;
    public MiniJogo2() : this("MiniGamesPage")
    {
    }
    public MiniJogo2(string origin)
    {
        InitializeComponent();
        OriginPage = origin;
        GenerateQuestion();

    }

    private void GenerateQuestion()
    {
        if (isPaused) return;

        if (rounds >= 10)
        {
            ShowScorePanel();
            return;
        }

        ResultLabel.Text = "";
        SetButtonsEnabled(true);

        LeftStack.Children.Clear();
        RightStack.Children.Clear();

        leftCount = rand.Next(1, 6);
        rightCount = rand.Next(1, 6);

        for (int i = 0; i < leftCount; i++)
            LeftStack.Children.Add(CreateImage());

        for (int i = 0; i < rightCount; i++)
            RightStack.Children.Add(CreateImage());

        rounds++;
    }

    private View CreateImage()
    {
        return new Image
        {
            Source = "apple.png",
            WidthRequest = 100,
            HeightRequest = 100,
            Margin = new Thickness(5),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }

    private void OnGreaterClicked(object sender, EventArgs e) => CheckAnswer(">");

    private void OnEqualClicked(object sender, EventArgs e) => CheckAnswer("=");

    private void OnLessClicked(object sender, EventArgs e) => CheckAnswer("<");

    private void CheckAnswer(string selected)
    {
        if (isPaused) return;

        SetButtonsEnabled(false);

        string correct = leftCount > rightCount ? ">" :
                         leftCount < rightCount ? "<" : "=";

        if (selected == correct)
        {
            score += 10;
            ResultLabel.Text = "Certo!🥳";
            ResultLabel.TextColor = Colors.Green;
        }
        else
        {
            ResultLabel.Text = $"Errado 😔. Era {correct}";
            ResultLabel.TextColor = Colors.Red;
        }

        ScoreLabel.Text = $"Pontuação: {score}";

        Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
        {
            if (!isPaused)
                GenerateQuestion();
            return false;
        });
    }

    private void SetButtonsEnabled(bool enabled)
    {
        GreaterButton.IsEnabled = enabled;
        EqualButton.IsEnabled = enabled;
        LessButton.IsEnabled = enabled;
    }

    private void ShowScorePanel()
    {
        FinalScoreLabel.Text = $"Pontuação final: {score}/100";
        FinalOverlay.IsVisible = true;
        isPaused = true;

        if (OriginPage == "JourneyPage")
        {
            HighScoresLabel.IsVisible = false;
            RestartButton.IsVisible = false;
            ClearButton.IsVisible = false;

            // Remove botões antigos se já existirem
            var layout = (StackLayout)((ScrollView)FinalOverlay.Content).Content;

            // Remove botões extras (como Next ou Tentar Novamente) se já adicionados
            var existingExtraButtons = layout.Children
                .OfType<Button>()
                .Where(b => b.Text == "Próximo Jogo" || b.Text == "Tentar Novamente")
                .ToList();

            foreach (var btn in existingExtraButtons)
                layout.Children.Remove(btn);

            if (score >= 50)
            {
                FinalScoreLabel.Text += "\nParabéns! Conseguiste!";
                var nextButton = new Button
                {
                    Text = "Próximo Jogo",
                    BackgroundColor = Color.FromArgb("#008000"),
                    TextColor = Colors.White,
                    FontFamily = "Delfino",
                    CornerRadius = 20
                };
                nextButton.Clicked += OnNextGameClicked;
                layout.Children.Insert(layout.Children.Count - 1, nextButton); // antes do botão Sair
            }
            else
            {
                FinalScoreLabel.Text += "\nFoi quase.😔";
                var tryAgainButton = new Button
                {
                    Text = "Tentar Novamente",
                    BackgroundColor = Color.FromArgb("#FF0000"),
                    TextColor = Colors.White,
                    FontFamily = "Delfino",
                    CornerRadius = 20
                };
                tryAgainButton.Clicked += OnRestartClicked;
                layout.Children.Insert(layout.Children.Count - 1, tryAgainButton); // antes do botão Sair
            }
        }
        else
        {
            HighScoresLabel.IsVisible = true;
            RestartButton.IsVisible = true;
            ClearButton.IsVisible = true;

            var highscores = Preferences.Get("HighScores_MJ2", "");
            var scores = string.IsNullOrEmpty(highscores)
                ? new List<int>()
                : highscores.Split(',').Select(int.Parse).ToList();

            scores.Add(score);
            scores = scores.OrderByDescending(s => s).Take(5).ToList();
            Preferences.Set("HighScores_MJ2", string.Join(",", scores));

            HighScoresLabel.Text = " Melhores Pontuações:\n" + string.Join("\n", scores);
        }
    }


    private void OnRestartClicked(object sender, EventArgs e)
    {
        score = 0;
        rounds = 0;
        isPaused = false;
        FinalOverlay.IsVisible = false;
        ResultLabel.Text = "";
        ScoreLabel.Text = "Pontuação: 0";
        GenerateQuestion();
    }

    private void OnClearHighScoresClicked(object sender, EventArgs e)
    {
        Preferences.Remove("HighScores_MJ2");
        HighScoresLabel.Text = " Melhores Pontuações:\n";
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
        isPaused = true;
        PauseMenu.IsVisible = true;
        SetButtonsEnabled(false);  // Desabilita os botões ao pausar
    }

    private void OnResumeClicked(object sender, EventArgs e)
    {
        isPaused = false;
        PauseMenu.IsVisible = false;
        SetButtonsEnabled(true);   // Reabilita os botões ao retomar
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

    private async void OnNextGameClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiniJogo3("JourneyPage")); // passa a origem
    }

}