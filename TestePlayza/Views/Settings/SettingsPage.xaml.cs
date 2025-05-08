using Microsoft.Maui.Controls;

namespace Playza.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // Método para mudar o tema
        private void OnThemeSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedTheme = button.Source.ToString(); // Pega a URL da imagem clicada
            // Aqui você pode aplicar a mudança de tema com base na imagem selecionada
        }

        // Método para mudar o ícone
        private void OnIconSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedIcon = button.Source.ToString(); // Pega o ícone selecionado
            // Aqui você pode aplicar o ícone escolhido
        }

        // Método para ajustar o tamanho da fonte
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

        // Método para salvar as alterações
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Lógica para salvar as configurações
        }

        // Método para sair da página de configurações
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MenuPage");
        }
    }
}