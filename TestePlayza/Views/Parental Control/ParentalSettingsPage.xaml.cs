using Microsoft.Maui.Controls;
using Playza.Models;
using Playza.Services;
using System;
using System.IO;
using Playza.Utils;

namespace Playza.Views
{
    public partial class ParentalSettingsPage : ContentPage
    {
        private readonly UserDatabase _userDatabase;
        private User _currentUser;

        public ParentalSettingsPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            _userDatabase = new UserDatabase(dbPath);

            _currentUser = Session.CurrentUser;

            if (_currentUser == null)
            {
                Shell.Current.GoToAsync("//MainPage");
                return;
            }

            PopulateFields();
        }

        private void PopulateFields()
        {
            UserNameLabel.Text = _currentUser.Name;
            NameEntry.Text = _currentUser.Name;
            NicknameEntry.Text = _currentUser.Username;
            PasswordEntry.Text = _currentUser.Password;
            ConfirmPasswordEntry.Text = _currentUser.Password;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Erro", "As palavras-passe não coincidem.", "OK");
                return;
            }

            _currentUser.Name = NameEntry.Text;
            _currentUser.Username = NicknameEntry.Text;
            _currentUser.Password = PasswordEntry.Text;

            await _userDatabase.UpdateUserAsync(_currentUser);

            await DisplayAlert("Sucesso", "Alterações guardadas com sucesso.", "OK");

            await Shell.Current.GoToAsync("ParentalControlPage");
        }

        private async void OnDeleteAccountClicked(object sender, EventArgs e)
        {
            if (DeletePasswordEntry.Text != DeleteConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Erro", "As palavras-passe não coincidem.", "OK");
                return;
            }

            if (DeletePasswordEntry.Text != _currentUser.Password)
            {
                await DisplayAlert("Erro", "Palavra-passe incorreta.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirmar", "Tens a certeza que queres eliminar a conta?", "Sim", "Não");
            if (!confirm)
                return;

            await _userDatabase.DeleteUserAsync(_currentUser);
            Session.CurrentUser = null;

            await DisplayAlert("Conta eliminada", "A tua conta foi eliminada com sucesso.", "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            await Shell.Current.GoToAsync("ParentalControlPage");
        }
    }
}