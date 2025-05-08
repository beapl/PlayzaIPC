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
            var button = (ImageButton)sender;
            var selectedTheme = button.Source.ToString(); // Pega a URL da imagem clicada
            // Aqui voc� pode aplicar a mudan�a de tema com base na imagem selecionada
        }

        // M�todo para mudar o �cone
        private void OnIconSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var selectedIcon = button.Source.ToString(); // Pega o �cone selecionado
            // Aqui voc� pode aplicar o �cone escolhido
        }

        // M�todo para ajustar o tamanho da fonte
        private void OnFontSizeChanged(object sender, ValueChangedEventArgs e)
        {
            var newSize = e.NewValue;
            //FontSizeLabel.Text = $"Tamanho da Fonte: {newSize}";
            // Aqui voc� pode ajustar o tamanho das fontes conforme necess�rio
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