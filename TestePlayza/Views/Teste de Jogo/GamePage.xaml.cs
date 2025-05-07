using Playza.Models;

namespace Playza.Views;

public partial class GamePage : ContentPage
{
    private List<Question> questions;
    private int currentQuestionIndex = 0;
    private int score = 0;

    public GamePage()
    {
        InitializeComponent();
        LoadQuestions();
        ShowQuestion();
    }

    private void LoadQuestions()
    {
        questions = new List<Question>
        {
            new Question
            {
                Text = "Quanto é 2 + 2?",
                Options = new List<string> { "3", "4", "5" },
                CorrectAnswer = "4"
            },
            new Question
            {
                Text = "Qual é a primeira letra do alfabeto?",
                Options = new List<string> { "A", "B", "C" },
                CorrectAnswer = "A"
            },
            new Question
            {
                Text = "Quantas pernas tem um cão?",
                Options = new List<string> { "2", "4", "6" },
                CorrectAnswer = "4"
            }
        };
    }

    private void ShowQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            DisplayFinalScore();
            return;
        }

        var question = questions[currentQuestionIndex];
        QuestionLabel.Text = question.Text;

        AnswersStack.Children.Clear();
        foreach (var answer in question.Options)
        {
            var button = new Button
            {
                Text = answer,
                BackgroundColor = Colors.Orange,
                TextColor = Colors.White,
                FontSize = 20
            };
            button.Clicked += OnAnswerClicked;
            AnswersStack.Children.Add(button);
        }
    }

    private void OnAnswerClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedAnswer = button.Text;
        var correctAnswer = questions[currentQuestionIndex].CorrectAnswer;

        if (selectedAnswer == correctAnswer)
        {
            score += 10;
        }

        currentQuestionIndex++;
        ScoreLabel.Text = $"Pontuação: {score}";
        ShowQuestion();
    }

    private async void DisplayFinalScore()
    {
        await DisplayAlert("Fim do Jogo!", $"Pontuação final: {score} pontos!", "OK");
        await Shell.Current.GoToAsync("MenuPage");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MenuPage");
    }
}
