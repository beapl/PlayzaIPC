using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace TestePlayza.Views
{
    public partial class MiniJogo1 : ContentPage
    {
        private int currentQuestion = 0;
        private int score = 0;
        private int correctAnswer;
        private readonly Random random = new();

        private readonly List<string> imageOptions = new()
        {
            "apple.png", "banana.png", "balloons.png"
        };

        public MiniJogo1()
        {
            InitializeComponent();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            if (currentQuestion >= 5)
            {
                QuestionLabel.Text = $"🎉 Fim do jogo!";
                FeedbackLabel.Text = $"Pontuação final: {score}/5";
                DisableButtons();
                return;
            }

            currentQuestion++;
            FeedbackLabel.Text = "";
            ImagePanel.Children.Clear();
            SetBackgroundGradient("#1D3557", "#1D3557"); 

            string image = imageOptions[random.Next(imageOptions.Count)];
            int a = random.Next(1, 6);
            int b = random.Next(1, 6);
            string op = new[] { "+", "-", "*" }[random.Next(3)];

            if (op == "-" && b > a)
                (a, b) = (b, a);

            correctAnswer = op switch
            {
                "+" => a + b,
                "-" => a - b,
                "x" => a * b,
                _ => 0
            };

            string opDisplay = op == "*" ? "x" : op;
            QuestionLabel.Text = $"{a} {opDisplay} {b} = ?";

            for (int i = 0; i < a; i++)
                ImagePanel.Children.Add(CreateImage(image));

            ImagePanel.Children.Add(new Label
            {
                Text = opDisplay,
                FontSize = 40,
                FontFamily = "Fredoka",
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                Padding = 10
            });

            for (int i = 0; i < b; i++)
                ImagePanel.Children.Add(CreateImage(image));

            var options = new List<int> { correctAnswer };
            while (options.Count < 3)
            {
                int wrong = random.Next(0, 21);
                if (!options.Contains(wrong))
                    options.Add(wrong);
            }

            var shuffled = options.OrderBy(_ => random.Next()).ToList();
            OptionButton1.Text = shuffled[0].ToString();
            OptionButton2.Text = shuffled[1].ToString();
            OptionButton3.Text = shuffled[2].ToString();

            EnableButtons();
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
            if (sender is Button btn && int.TryParse(btn.Text, out int answer))
            {
                if (answer == correctAnswer)
                {
                    FeedbackLabel.Text = "✅ Correto!";
                    score++;
                    SetBackgroundGradient("#11998e", "#38ef7d"); // tentativa gradiente verde quando correta
                }
                else
                {
                    FeedbackLabel.Text = $"❌ Errado! Era {correctAnswer}";
                    SetBackgroundGradient("#cb2d3e", "#ef473a"); // tentativa gradiente vermelho quando correta
                }

                DisableButtons();

                Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
                {
                    GenerateQuestion();
                    return false;
                });
            }
        }

        private void EnableButtons()
        {
            OptionButton1.IsEnabled = true;
            OptionButton2.IsEnabled = true;
            OptionButton3.IsEnabled = true;
        }

        private void DisableButtons()
        {
            OptionButton1.IsEnabled = false;
            OptionButton2.IsEnabled = false;
            OptionButton3.IsEnabled = false;
        }

        private void SetBackgroundGradient(string color1, string color2)
        {
            MainGrid.Background = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Color.FromArgb(color1), 0f),
                    new GradientStop(Color.FromArgb(color2), 1f)
                }
            };
        }
    }
}