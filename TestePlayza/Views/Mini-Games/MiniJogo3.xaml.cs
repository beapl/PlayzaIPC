namespace Playza.Views
{
    public partial class MiniJogo3 : ContentPage
    {
        List<(string Animal, string Initial)> animalList;
        int currentAnimalIndex = 0;
        int score = 0;

        public MiniJogo3()
        {
            InitializeComponent();
            ShuffleAnimals();
            Dispatcher.Dispatch(() => LoadNewAnimal());
        }

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
            if (currentAnimalIndex >= animalList.Count)
            {
                FeedbackLabel.Text = "🎉Acabou!🎉";
                FeedbackLabel.TextColor = Colors.Black;
                ScoreLabel.Text = $"Pontuação final: {score}";
                LettersLayout.IsVisible = false;
                return;
            }

            QuestionLabel.Text = "Qual é a inicial deste animal?";
            var (animal, _) = animalList[currentAnimalIndex];
            AnimalImage.Source = $"{animal.ToLower()}.jpg";
            ScoreLabel.Text = $"Pontuação: {score}";
        }

        private void OnLetterClicked(object sender, EventArgs e)
        {
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

                currentAnimalIndex++;
                LoadNewAnimal();
            }
        }
    }
}
