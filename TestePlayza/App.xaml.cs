using Playza;
using Playza.Services;
using System.IO;
using Microsoft.Maui.Storage;

namespace Playza
{
    public partial class App : Application
    {
        // Instância do banco de dados
        public static UserDatabase Database { get; private set; }

        // Tracker de uso (presumo que você tenha alguma lógica aqui que ainda não foi detalhada)
        private readonly UsageTracker _usageTracker = new UsageTracker();

        public App()
        {
            InitializeComponent();

            // Configura a página inicial (app shell)
            MainPage = new AppShell();

            // Navegação inicial (opcional, dependendo de como você quer o fluxo de navegação)
            Shell.Current.GoToAsync("//MainPage");

            // Caminho para o banco de dados SQLite
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

            // Instancia o banco de dados SQLite
            Database = new UserDatabase(dbPath);
        }

        // Método necessário para a criação da aplicação Maui
        public static MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}

