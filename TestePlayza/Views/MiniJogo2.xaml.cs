namespace Playza.Views;

public partial class MiniJogo2 : ContentPage
{
    int leftCount;
    int rightCount;
    int score = 0;
    int rounds = 0; // Contador de rodadas
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
            // Fim do jogo, exibe a pontuação final e reinicia
            ResultLabel.Text = $"🎉Fim de Jogo!🎉";
            ResultLabel.FontSize = 40;
            ResultLabel.TextColor = Colors.Black;
            ScoreLabel.Text = $"Pontuação final: {score}";
            SetButtonsEnabled(false);  // Desabilita os botões
            return;
        }

        ResultLabel.Text = "";
        SetButtonsEnabled(true);

        LeftStack.Children.Clear();
        RightStack.Children.Clear();

        leftCount = rand.Next(1, 6);
        rightCount = rand.Next(1, 6);

        // Adiciona as imagens à esquerda
        for (int i = 0; i < leftCount; i++)
            LeftStack.Children.Add(CreateImage());

        // Adiciona as imagens à direita
        for (int i = 0; i < rightCount; i++)
            RightStack.Children.Add(CreateImage());

        rounds++;  // Incrementa o número de rodadas
    }

    // Criação da imagem de maçã
    private View CreateImage()
    {
        return new Image
        {
            Source = "apple.png",  // Certifique-se de que o caminho da imagem está correto
            WidthRequest = 100,     // Ajuste o tamanho da imagem conforme necessário
            HeightRequest = 100,    // Ajuste o tamanho da imagem conforme necessário
            Margin = new Thickness(5),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }

    // Botões de interação
    private void OnGreaterClicked(object sender, EventArgs e) => CheckAnswer(">");
    private void OnEqualClicked(object sender, EventArgs e) => CheckAnswer("=");
    private void OnLessClicked(object sender, EventArgs e) => CheckAnswer("<");

    private void SetButtonsEnabled(bool isEnabled)
    {
        GreaterButton.IsEnabled = isEnabled;
        EqualButton.IsEnabled = isEnabled;
        LessButton.IsEnabled = isEnabled;
    }

    // Verificação da resposta
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

        // Replacing Device.StartTimer with Dispatcher.StartTimer
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
        {
            GenerateQuestion(); // Chama GenerateQuestion novamente para a próxima rodada
            return false; // Stops the timer
        });
    }
}
