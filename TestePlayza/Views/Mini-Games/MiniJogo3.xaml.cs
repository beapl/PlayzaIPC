namespace Playza.Views
{
    public partial class MiniJogo3 : ContentPage
    {
        List<(string Animal, string Initial)> animalList;
        int currentAnimalIndex = 0;
        int score = 0;
        bool isPaused = false;
        private string OriginPage;
        public MiniJogo3() : this("MiniGamesPage")
        {
        }

        public MiniJogo3(string origin)
        {
            InitializeComponent();
            ShuffleAnimals();
            Dispatcher.Dispatch(() => LoadNewAnimal());
            OriginPage = origin;

        }

        // Baralhar os animais com as respetivas iniciais
        private void ShuffleAnimals()
        {
            var original = new List<(string, string)>
            {
                ("foca", "F"),
                ("pinguim", "P"),
                ("burro", "B"),
                ("gato", "G"),
                ("panda", "P")
            };

            var random = new Random();
            animalList = original.OrderBy(item => random.Next()).ToList();
        }

        private void LoadNewAnimal()
        {
            if (isPaused) return;

            if (currentAnimalIndex >= animalList.Count)
            {
                ShowScorePanel();
                return;
            }

            QuestionLabel.Text = "Qual é a inicial deste animal?";
            var (animal, _) = animalList[currentAnimalIndex];
            AnimalImage.Source = $"{animal.ToLower()}.jpg";
            ScoreLabel.Text = $"Pontuação: {score}";
            FeedbackLabel.Text = "";
            LettersLayout.IsVisible = true;
        }


        private void OnLetterClicked(object sender, EventArgs e)
        {
            if (isPaused) return;

            if (sender is Button button)
            {
                string selectedLetter = button.Text;
                string correctInitial = animalList[currentAnimalIndex].Initial;

                if (selectedLetter == correctInitial)
                {
                    FeedbackLabel.Text = "Acertaste! 🥳";
                    FeedbackLabel.TextColor = Colors.Green;
                    score += 10;
                }
                else
                {
                    FeedbackLabel.Text = $"Erraste! Era {correctInitial} 😔";
                    FeedbackLabel.TextColor = Colors.Red;
                }

                // Atualiza o score e feedback imediatamente
                ScoreLabel.Text = $"Pontuação: {score}";
                LettersLayout.IsEnabled = false; // Evita múltiplos cliques

                // Mostra imagem atual ANTES de avançar
                var (animal, _) = animalList[currentAnimalIndex];
                AnimalImage.Source = $"{animal.ToLower()}.jpg";

                currentAnimalIndex++;

                // Espera e carrega próximo animal
                Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
                {
                    LettersLayout.IsEnabled = true;
                    LoadNewAnimal();
                    return false;
                });
            }
        }



        private void OnPauseClicked(object sender, EventArgs e)
        {
            isPaused = true;
            PauseMenu.IsVisible = true;
            LettersLayout.IsEnabled = false;
        }

        private void OnResumeClicked(object sender, EventArgs e)
        {
            isPaused = false;
            PauseMenu.IsVisible = false;
            LettersLayout.IsEnabled = true;
        }

        private void ShowScorePanel()
        {
            FinalScoreLabel.Text = $"Pontuação final: {score}";
            FinalOverlay.IsVisible = true;
            isPaused = true;

            var layout = (StackLayout)((ScrollView)FinalOverlay.Content).Content;

            if (OriginPage == "JourneyPage")
            {
                HighScoresLabel.IsVisible = false;
                RestartButton.IsVisible = false;
                ClearHighScoresButton.IsVisible = false;

                // Remove quaisquer botões extras que possam existir, removendo antes os eventos
                var existingExtraButtons = layout.Children
                    .OfType<Button>()
                    .Where(b => b.Text == "Próximo Jogo" || b.Text == "Tentar Novamente")
                    .ToList();

                foreach (var btn in existingExtraButtons)
                {
                    btn.Clicked -= OnNextGameClicked;
                    btn.Clicked -= OnRestartClicked;
                    layout.Children.Remove(btn);
                }

                if (score > 3)
                {
                    FinalScoreLabel.Text += "\nParabéns! Passaste de nível!";

                    var nextButton = new Button
                    {
                        Text = "Próximo Jogo",
                        BackgroundColor = Color.FromArgb("#008000"),
                        TextColor = Colors.White,
                        FontFamily = "Delfino",
                        CornerRadius = 20
                    };
                    nextButton.Clicked += OnNextGameClicked;

                    layout.Children.Insert(layout.Children.Count - 1, nextButton);
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

                    layout.Children.Insert(layout.Children.Count - 1, tryAgainButton);
                }
            }
            else
            {
                HighScoresLabel.IsVisible = true;
                RestartButton.IsVisible = true;
                ClearHighScoresButton.IsVisible = true;

                var highscores = Preferences.Get("HighScores_MJ3", "");
                var scores = string.IsNullOrEmpty(highscores)
                    ? new List<int>()
                    : highscores.Split(',').Select(int.Parse).ToList();

                scores.Add(score);
                scores = scores.OrderByDescending(s => s).Take(5).ToList();
                Preferences.Set("HighScores_MJ3", string.Join(",", scores));

                HighScoresLabel.Text = " Melhores Pontuações:\n" + string.Join("\n", scores);

                NextGameButton.IsVisible = false;
            }
        }





        private void OnRestartClicked(object sender, EventArgs e)
        {
            score = 0;
            currentAnimalIndex = 0;
            isPaused = false;
            FinalOverlay.IsVisible = false;
            FeedbackLabel.Text = "";
            ScoreLabel.Text = "Pontuação: 0";
            LettersLayout.IsVisible = true;
            ShuffleAnimals();
            LoadNewAnimal();
        }

        private void OnClearHighScoresClicked(object sender, EventArgs e)
        {
            Preferences.Remove("HighScores_MJ3");
            HighScoresLabel.Text = " Melhores Pontuações:\n";
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
            await Navigation.PushAsync(new MiniJogo4("JourneyPage")); // passa a origem
        }

    }
}