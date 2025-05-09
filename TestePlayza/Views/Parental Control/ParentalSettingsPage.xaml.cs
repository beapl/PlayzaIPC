namespace Playza.Views;

public partial class ParentalSettingsPage : ContentPage
{
	public ParentalSettingsPage()
	{
		InitializeComponent();
	}

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Erro", "As palavras-passe n�o coincidem.", "OK");
            return;
        }

        // Aqui colocarias a l�gica para guardar as altera��es (ex: chamada a base de dados ou API)
        // Exemplo fict�cio:
        // await AccountService.UpdateUser(NameEntry.Text, NicknameEntry.Text, PasswordEntry.Text);

        await DisplayAlert("Sucesso", "Altera��es guardadas com sucesso.", "OK");

        // Navegar de volta para a p�gina principal
        await Shell.Current.GoToAsync("ParentalControlPage"); // Assumindo que MainPage est� registada como rota no Shell
    }

    private async void OnDeleteAccountClicked(object sender, EventArgs e)
    {
        if (DeletePasswordEntry.Text != DeleteConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Erro", "As palavras-passe n�o coincidem.", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Confirmar", "Tens a certeza que queres eliminar a conta?", "Sim", "N�o");
        if (!confirm)
            return;

        // Aqui colocarias a l�gica para eliminar a conta (ex: chamada a API)
        // Exemplo fict�cio:
        // await AccountService.DeleteAccount(DeletePasswordEntry.Text);

        await DisplayAlert("Conta eliminada", "A tua conta foi eliminada com sucesso.", "OK");

        // Voltar � p�gina inicial
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ParentalControlPage");
    }
}