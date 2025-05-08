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
        private void OnFontSizeChanged(object sender, ValueChangedEventArgs e)
        {
            var newSize = e.NewValue;
            //FontSizeLabel.Text = $"Tamanho da Fonte: {newSize}";
            // Aqui você pode ajustar o tamanho das fontes conforme necessário
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