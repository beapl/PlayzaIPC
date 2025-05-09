namespace Playza.Views;

public partial class MiniJogo2 : ContentPage
{
    int leftCount;
    int rightCount;
    int score = 0;
    int rounds = 0; 
    Random rand = new Random();

    public MiniJogo2()
    {
        InitializeComponent();
        GenerateQuestion();
    }

    private void GenerateQuestion()
    {
        if (rounds >= 10)
        {

            ResultLabel.Text = $"🎉Fim de Jogo!🎉";
            ResultLabel.FontSize = 40;
            ResultLabel.TextColor = Colors.Black;
            ScoreLabel.Text = $"Pontuação final: {score}";
            SetButtonsEnabled(false); 
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

    private void SetButtonsEnabled(bool isEnabled)
    {
        GreaterButton.IsEnabled = isEnabled;
        EqualButton.IsEnabled = isEnabled;
        LessButton.IsEnabled = isEnabled;
    }
    private async void OnPauseClicked(object sender, EventArgs e)
    {
        var result = await DisplayActionSheet("Pausado", "Cancelar", null, "Continuar", "Sair");

        if (result == "Sair")
        {
            await Navigation.PopAsync();
        }
    }

    private void CheckAnswer(string selected)
    {
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
            GenerateQuestion();
            return false; 
        });
    }
}