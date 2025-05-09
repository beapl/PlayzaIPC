using Playza;
using Playza.Services;
using System.IO;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;


namespace Playza
{
    public partial class App : Application
    {
        // Instância do banco de dados
        public static UserDatabase Database { get; private set; }

        // Tracker de uso (presumo que você tenha alguma lógica aqui que ainda não foi detalhada)
        private readonly UsageTracker _usageTracker = new UsageTracker();

        private IAudioManager _audioManager;
        private IAudioPlayer _player;

        public App()
        {
            InitializeComponent();

            // Inicializa o AudioManager
            _audioManager = AudioManager.Current;

            // Inicia a música de fundo
            PlayBackgroundMusic();

            // Configura a página inicial (app shell)
            MainPage = new AppShell();

            // Navegação inicial (opcional, dependendo de como você quer o fluxo de navegação)
            Shell.Current.GoToAsync("//MainPage");

            // Caminho para o banco de dados SQLite
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

            // Instancia o banco de dados SQLite
            Database = new UserDatabase(dbPath);
        }

        private async void PlayBackgroundMusic()
        {
            try
            {
                // Caminho do arquivo de áudio (certifique-se de que a música está na pasta raw)
                var file = await FileSystem.OpenAppPackageFileAsync("backgroundmusic.mp3");

                // Cria um player de áudio
                _player = _audioManager.CreatePlayer(file);

                // Configura o player para repetir a música
                _player.Loop = true;

                // Toca a música
                _player.Play();
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro ao carregar a música
                Console.WriteLine($"Erro ao tocar a música: {ex.Message}");
            }
        }

        // Método necessário para a criação da aplicação Maui
        public static MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}

