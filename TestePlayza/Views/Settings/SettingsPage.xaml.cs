using Microsoft.Maui.Controls;

namespace Playza.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // M�todo para mudar o tema
        private void OnThemeSelected(object sender, EventArgs e)
        {
            // Aqui voc� pode identificar qual tema foi selecionado
            var button = sender as ImageButton;

            if (button != null)
            {
                // Alterar o tema de acordo com o bot�o clicado
                switch (button.Source.ToString()) // Verificando a imagem do bot�o clicado
                {
                    case "tema0.png":
                        BackgroundImageSource = "tema0.png"; // Mudar a imagem de fundo para tema0
                        break;
                    case "tema1.png":
                        BackgroundImageSource = "tema1.png"; // Mudar a imagem de fundo para tema1
                        break;
                    case "tema2.png":
                        BackgroundImageSource = "tema2.png"; // Mudar a imagem de fundo para tema2
                        break;
                    case "tema3.png":
                        BackgroundImageSource = "tema3.png"; // Mudar a imagem de fundo para tema3
                        break;
                    default:
                        break;
                }
            }
        }

        // M�todo para mudar o �cone
        private void OnIconSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedIcon = button.Source.ToString(); // Pega o �cone selecionado
            // Aqui voc� pode aplicar o �cone escolhido
        }

        // M�todo para ajustar o tamanho da fonte
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

        // M�todo para salvar as altera��es
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // L�gica para salvar as configura��es
        }

        // M�todo para sair da p�gina de configura��es
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MenuPage");
        }
    }
}