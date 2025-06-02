using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;
using Playza.Services;
using Playza.Models;

namespace Playza.Views
{
    public partial class MiniJogo1 : ContentPage
    {
        private int currentQuestion = 0;
        private int score = 0;
        private int correctAnswer;
        private bool isPaused = false;
        private readonly Random random = new();
        private string OriginPage;

        private readonly List<string> imageOptions = new()
        {
            "apple.png", "banana.png", "balloons.png"
        };

        private readonly DateTime startTime;

        // Construtores
        public MiniJogo1() : this(DateTime.Now)
        {
        }

        public MiniJogo1(DateTime startTime) : this(startTime, "MiniGamesPage")
        {
        }

        public MiniJogo1(DateTime startTime, string origin)
        {
            InitializeComponent();
            this.startTime = startTime;
            OriginPage = origin;
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            if (isPaused) return;

            if (currentQuestion >= 10)
            {
                ShowScorePanel();
                return;
            }

            currentQuestion++;
            FeedbackLabel.Text = "";
            ImagePanel.Children.Clear();

            string image = imageOptions[random.Next(imageOptions.Count)];
            int a = random.Next(1, 6);
            int b = random.Next(1, 6);
            string op = new[] { "+", "-" }[random.Next(2)];

            if (op == "-" && b > a)
                (a, b) = (b, a);

            correctAnswer = op switch
            {
                "+" => a + b,
                "-" => a - b,
                _ => 0
            };

            string opDisplay = op == "*" ? "×" : op == "/" ? "÷" : op;

            QuestionLabel.Text = $"{a} {opDisplay} {b} = ?";

            // Adiciona imagens do primeiro número
            for (int i = 0; i < a; i++)
                ImagePanel.Children.Add(CreateImage(image));

            // Adiciona o sinal da operação em PRETO
            ImagePanel.Children.Add(new Label
            {
                Text = opDisplay,
                FontSize = 40,
                FontFamily = "Fredoka",
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Center,
                Padding = 10
            });

            // Adiciona imagens do segundo número
            for (int i = 0; i < b; i++)
                ImagePanel.Children.Add(CreateImage(image));

            var options = new List<int> { correctAnswer };
            while (options.Count < 5)
            {
                int wrong = random.Next(0, 16);
                if (!options.Contains(wrong))
                    options.Add(wrong);
            }

            var shuffled = options.OrderBy(_ => random.Next()).ToList();
            OptionButton1.Text = shuffled[0].ToString();
            OptionButton2.Text = shuffled[1].ToString();
            OptionButton3.Text = shuffled[2].ToString();
            OptionButton4.Text = shuffled[3].ToString();
            OptionButton5.Text = shuffled[4].ToString();

            EnableButtons();
            ScoreLabel.Text = $"Pontuação: {score}";
        }

        private Image CreateImage(string filename)
        {
            return new Image
            {
                Source = $"Resources/Images/{filename}",
                WidthRequest = 100,
                HeightRequest = 100
            };
        }

        private void OnAnswerClicked(object sender, EventArgs e)
        {
            if (isPaused) return;

            if (sender is Button btn && int.TryParse(btn.Text, out int answer))
            {
                if (answer == correctAnswer)
                {
                    FeedbackLabel.Text = "Correto!";
                    FeedbackLabel.TextColor = Colors.Green;
                    score++;
                    ScoreLabel.Text = $"Pontuação: {score}";
                }
                else
                {
                    FeedbackLabel.Text = $"Errado! Era {correctAnswer}";
                    FeedbackLabel.TextColor = Colors.Red;
                }

                DisableButtons();

                Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
                {
                    if (!isPaused)
                    {
                        GenerateQuestion();
                    }
                    else
                    {
                        Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
                        {
                            if (!isPaused)
                            {
                                GenerateQuestion();
                                return false;
                            }
                            return true;
                        });
                    }
                    return false;
                });
            }
        }

        private void EnableButtons()
        {
            OptionButton1.IsEnabled = true;
            OptionButton2.IsEnabled = true;
            OptionButton3.IsEnabled = true;
            OptionButton4.IsEnabled = true;
            OptionButton5.IsEnabled = true;
        }

        private void DisableButtons()
        {
            OptionButton1.IsEnabled = false;
            OptionButton2.IsEnabled = false;
            OptionButton3.IsEnabled = false;
            OptionButton4.IsEnabled = false;
            OptionButton5.IsEnabled = false;
        }

        private void ShowScorePanel()
        {
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            // Guardar relatório no GameSessionManager
            GameSessionManager.Instance.AddMiniGameReport(new MiniGameReport
            {
                GameName = "MiniJogo1",
                StartTime = startTime,
                EndTime = endTime,
                TimeTaken = duration
            });

            QuestionLabel.Text = "Fim do jogo!";
            ScorePanel.IsVisible = true;
            FinalScoreLabel.Text = $"Pontuação final: {score}/10";

            // Remove quaisquer botões exceto os principais
            for (int i = ScorePanelStack.Children.Count - 1; i >= 0; i--)
            {
                var child = ScorePanelStack.Children[i];
                if (child is Button btn &&
                    btn != RestartButton &&
                    btn != ClearHighScoresButton &&
                    btn != ExitButton)
                {
                    ScorePanelStack.Children.RemoveAt(i);
                }
            }

            if (OriginPage == "JourneyPage")
            {
                if (score >= 5)
                {
                    FinalScoreLabel.Text += "\nParabéns! Conseguiste!";
                }
                else
                {
                    FinalScoreLabel.Text += "\nFoi quase.😔";
                }

                HighScoresLabel.IsVisible = false;

                RestartButton.IsVisible = false;
                ClearHighScoresButton.IsVisible = false;
                ExitButton.IsVisible = true;

                var nextButton = new Button
                {
                    Text = score >= 5 ? "Próximo Jogo" : "Tentar Novamente",
                    BackgroundColor = score >= 5 ? Colors.Green : Colors.Red,
                    TextColor = Colors.White,
                    FontFamily = "Delfino",
                    CornerRadius = 20
                };
                nextButton.Clicked += score >= 5 ? OnNextGameClicked : OnRestartClicked;

                int exitIndex = ScorePanelStack.Children.IndexOf(ExitButton);

                if (exitIndex > 0)
                {
                    ScorePanelStack.Children.Insert(exitIndex, nextButton);
                }
                else
                {
                    ScorePanelStack.Children.Insert(ScorePanelStack.Children.Count - 1, nextButton);
                }
            }
            else
            {
                if (score >= 5)
                {
                    Preferences.Set("Icon2Unlocked", true); // <<< adiciona aqui para fora da JourneyPage também
                }

                var highscores = Preferences.Get("HighScores", "");
                var scores = string.IsNullOrEmpty(highscores)
                    ? new List<int>()
                    : highscores.Split(',').Select(int.Parse).ToList();

                scores.Add(score);
                scores = scores.OrderByDescending(s => s).Take(5).ToList();
                Preferences.Set("HighScores", string.Join(",", scores));

                HighScoresLabel.Text = " Melhores Pontuações:\n" + string.Join("\n", scores);
            }
        }

        private void OnRestartClicked(object sender, EventArgs e)
        {
            currentQuestion = 0;
            score = 0;
            ScoreLabel.Text = "Pontuação: 0";
            isPaused = false;
            ScorePanel.IsVisible = false;
            GenerateQuestion();
        }

        private void OnClearHighScoresClicked(object sender, EventArgs e)
        {
            Preferences.Remove("HighScores");
            HighScoresLabel.Text = " Melhores Pontuações:\n";
        }

        private void OnPauseClicked(object sender, EventArgs e)
        {
            isPaused = true;
            PauseMenu.IsVisible = true;
        }

        private void OnResumeClicked(object sender, EventArgs e)
        {
            isPaused = false;
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

        private async void OnNextGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MiniJogo2(DateTime.Now, "JourneyPage"));

        }
    }
}
