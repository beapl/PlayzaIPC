using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
using Playza.Utils;

namespace Playza.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

        }

        /* private void OnThemeSelected(object sender, EventArgs e)
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
        } */

        private void OnThemeSelected(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            if (button?.Source is FileImageSource fileImageSource)
            {
                var selectedImage = fileImageSource.File;
                BackgroundImage.Source = selectedImage;

                // Guardar a escolha do utilizador
                Preferences.Set("SelectedBackground", selectedImage);
            }
        }


        /* private void OnFontSizeSliderChanged(object sender, ValueChangedEventArgs e)
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
        } */

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

            // Aplica a imagem de fundo guardada
            var savedImage = Preferences.Get("SelectedBackground", "wallpaper.jpg");
            BackgroundImage.Source = savedImage;

            if (App.BackgroundPlayer != null)
            {
                MusicSwitch.IsToggled = App.BackgroundPlayer.IsPlaying;
            }

            bool icon2Unlocked = Preferences.Get("Icon2Unlocked", false);
            if (icon2Unlocked)
            {
                // Torna vis�vel ou habilita o bot�o de �cone
                Icon2Button.IsEnabled = true;
                Icon2Button.Opacity = 1;
            }
            else
            {
                Icon2Button.IsEnabled = false;
                Icon2Button.Opacity = 0.5; // Ou outra apar�ncia de "bloqueado"
            }


            bool icon3Unlocked = Preferences.Get("Icon3Unlocked", false);
            if (icon3Unlocked)
            {
                // Torna vis�vel ou habilita o bot�o de �cone
                Icon3Button.IsEnabled = true;
                Icon3Button.Opacity = 1;
            }
            else
            {
                Icon3Button.IsEnabled = false;
                Icon3Button.Opacity = 0.5; // Ou outra apar�ncia de "bloqueado"
            }


            bool icon4Unlocked = Preferences.Get("Icon4Unlocked", false);
            if (icon4Unlocked)
            {
                // Torna vis�vel ou habilita o bot�o de �cone
                Icon4Button.IsEnabled = true;
                Icon4Button.Opacity = 1;
            }
            else
            {
                Icon4Button.IsEnabled = false;
                Icon4Button.Opacity = 0.5; // Ou outra apar�ncia de "bloqueado"
            }

            bool icon5Unlocked = Preferences.Get("Icon5Unlocked", false);
            if (icon5Unlocked)
            {
                // Torna vis�vel ou habilita o bot�o de �cone
                Icon5Button.IsEnabled = true;
                Icon5Button.Opacity = 1;
            }
            else
            {
                Icon5Button.IsEnabled = false;
                Icon5Button.Opacity = 0.5; // Ou outra apar�ncia de "bloqueado"
            }

            bool icon6Unlocked = Preferences.Get("Icon6Unlocked", false);
            if (icon6Unlocked)
            {
                // Torna vis�vel ou habilita o bot�o de �cone
                Icon6Button.IsEnabled = true;
                Icon6Button.Opacity = 1;
            }
            else
            {
                Icon6Button.IsEnabled = false;
                Icon6Button.Opacity = 0.5; // Ou outra apar�ncia de "bloqueado"
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

        private async void OnIconSelected(object sender, EventArgs e)
        {
          
        }
    }
}