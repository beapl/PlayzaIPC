namespace Playza.Views;

public partial class MiniJogo2 : ContentPage
{
    int leftCount;
    int rightCount;
    private int score = 0;

    Random rand = new Random();

    public MiniJogo2()
    {
        InitializeComponent();
        GenerateQuestion();
    }

    private void GenerateQuestion()
    {
        ResultLabel.Text = "";

        LeftStack.Children.Clear();
        RightStack.Children.Clear();

        leftCount = rand.Next(1, 6);   // entre 1 e 5
        rightCount = rand.Next(1, 6);

        for (int i = 0; i < leftCount; i++)
        {
            LeftStack.Children.Add(CreateImage());
        }

        for (int i = 0; i < rightCount; i++)
        {
            RightStack.Children.Add(CreateImage());
        }
    }

    private View CreateImage()
    {
        return new Image
        {
            Source = "apple.png",
            WidthRequest = 40,
            HeightRequest = 40,
            Margin = new Thickness(5)
        };
    }


    private void OnGreaterClicked(object sender, EventArgs e)
    {
        CheckAnswer(">");
    }

    private void OnEqualClicked(object sender, EventArgs e)
    {
        CheckAnswer("=");
    }

    private void OnLessClicked(object sender, EventArgs e)
    {
        CheckAnswer("<");
    }

    private void CheckAnswer(string selected)
    {
        string correct;

        if (leftCount > rightCount) correct = ">";
        else if (leftCount < rightCount) correct = "<";
        else correct = "=";

        if (selected == correct)
        {
            score += 10;
            ResultLabel.Text = "Certo! ";
            ResultLabel.TextColor = Colors.Green;
        }
        else
        {
            ResultLabel.Text = $"Errado. Era {correct}";
            ResultLabel.TextColor = Colors.Red;
        }

        ScoreLabel.Text = $"Pontuação: {score}";

        // Espera e gera nova questão
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            GenerateQuestion();
            return false;
        });
    }
}
