using Microsoft.Maui.Controls;

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
            // aplicar o ícone escolhido aqui
        }

        private void OnFontSizeSliderChanged(object sender, ValueChangedEventArgs e)
        {
            // Arredonda para o valor mais próximo: 0 (esquerda), 1 (meio), 2 (direita)
            int snappedValue = (int)Math.Round(e.NewValue);
            FontSizeSlider.Value = snappedValue; // bloqueia o slider nessa posição

            // Atualiza o label
            switch (snappedValue)
            {
                case 0:
                    FontSizeLabel.Text = "Pequeno";
                    break;
                case 1:
                    FontSizeLabel.Text = "Médio";
                    break;
                case 2:
                    FontSizeLabel.Text = "Grande";
                    break;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Lógica para salvar as configurações
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MenuPage");
        }
    }
}