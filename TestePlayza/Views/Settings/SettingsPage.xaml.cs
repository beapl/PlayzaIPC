using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;

namespace Playza.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void OnThemeSelected(object sender, EventArgs e)
        {

            var button = sender as ImageButton;

            if (button != null)
            {
                switch (button.Source.ToString()) 
                {
                    case "tema0.png":
                        BackgroundImageSource = "tema0.png"; 
                        break;
                    case "tema1.png":
                        BackgroundImageSource = "tema1.png";
                        break;
                    case "tema2.png":
                        BackgroundImageSource = "tema2.png"; 
                        break;
                    case "tema3.png":
                        BackgroundImageSource = "tema3.png"; 
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnIconSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedIcon = button.Source.ToString(); 
            // aplicar o �cone escolhido aqui
        }

        private void OnFontSizeSliderChanged(object sender, ValueChangedEventArgs e)
        {
            // Arredonda para o valor mais pr�ximo: 0 (esquerda), 1 (meio), 2 (direita)
            int snappedValue = (int)Math.Round(e.NewValue);
            FontSizeSlider.Value = snappedValue; // bloqueia o slider nessa posi��o

            // Atualiza o label
            switch (snappedValue)
            {
                case 0:
                    FontSizeLabel.Text = "Pequeno";
                    break;
                case 1:
                    FontSizeLabel.Text = "M�dio";
                    break;
                case 2:
                    FontSizeLabel.Text = "Grande";
                    break;
            }
        }

        private void OnMusicSwitchToggled(object sender, ToggledEventArgs e)
        {
            var player = App.BackgroundPlayer;

            if (player == null)
            {
                return; // Player ainda n�o foi carregado
            }

            if (e.Value)
            {
                player.Play(); // Ligar m�sica
            }
            else
            {
                player.Pause(); // Desligar m�sica
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.BackgroundPlayer != null)
            {
                MusicSwitch.IsToggled = App.BackgroundPlayer.IsPlaying;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // L�gica para salvar as configura��es
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MenuPage");
        }
    }
}