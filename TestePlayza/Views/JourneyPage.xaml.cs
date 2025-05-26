namespace Playza.Views;

public partial class JourneyPage : ContentPage
{
    private DateTime levelStartTime;
    public JourneyPage()
    {
        InitializeComponent();
    }

    private async void OnMiniGame1Clicked(object sender, EventArgs e)
    {
        levelStartTime = DateTime.Now;

        // Navega para a página do jogo, passando o tempo de início
        await Navigation.PushAsync(new MiniJogo1(DateTime.Now, "JourneyPage"));


        //await Navigation.PushAsync(new MiniJogo1("JourneyPage"));
    }

    private async void OnMiniGame2Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo2");
    }

    private async void OnMiniGame3Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo3");
    }

    private async void OnMiniGame4Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MiniJogo4");
    }
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MenuPage");
    }

}