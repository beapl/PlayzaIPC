namespace Playza.Views
{
    public partial class MiniJogo3 : ContentPage
    {
        string[] animals = { "foca", "pinguim", "burro", "gato", "panda" };
        string[] initials = { "F", "P", "B", "G", "P" };
        int currentAnimalIndex = 0;
        int score = 0;

        public MiniJogo3()
        {
            InitializeComponent();
            Dispatcher.Dispatch(() => LoadNewAnimal());
        }

        // Carrega o novo animal e a pergunta
        private void LoadNewAnimal()
        {
            if (currentAnimalIndex >= animals.Length)
            {
                // Jogo termina
                FeedbackLabel.Text = "🎉Acabou!🎉";
                FeedbackLabel.TextColor = Colors.Black;
                ScoreLabel.Text = $"Pontuação final: {score}";
                LettersLayout.IsVisible = false;
                return;
            }
            // Atualiza a pergunta
            QuestionLabel.Text = "Qual é a inicial deste animal?";

            // Define o animal e a sua imagem correspondente
            string animal = animals[currentAnimalIndex];
            AnimalImage.Source = $"{animal.ToLower()}.jpg"; // Certifique-se de que a imagem está corretamente nomeada

            // Reseta o feedback
            ScoreLabel.Text = $"Pontuação: {score}";
        }

        // Verifica a letra clicada e mostra o feedback
        private void OnLetterClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string selectedLetter = button.Text;

                // Verifica se a letra selecionada é a correta
                if (selectedLetter == initials[currentAnimalIndex])
                {
                    FeedbackLabel.Text = "Acertaste! 🥳";
                    FeedbackLabel.TextColor = Colors.Green;
                    score += 10;

                    // Avança para o próximo animal
                    currentAnimalIndex = (currentAnimalIndex + 1);

                    // Atualiza a pergunta e a imagem para o próximo animal
                    LoadNewAnimal();
                }
                else
                {
                    FeedbackLabel.Text =  $"Erraste! Era {initials[currentAnimalIndex]} 😔 ";
                    FeedbackLabel.TextColor = Colors.Red;
                    currentAnimalIndex = (currentAnimalIndex + 1);
                    LoadNewAnimal();
                }
            }
        }
    }
}

