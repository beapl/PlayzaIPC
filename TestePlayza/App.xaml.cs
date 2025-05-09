using Playza;
using Playza.Services;
using System.IO;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;


namespace Playza
{
    public partial class App : Application
    {
        public static UserDatabase Database { get; private set; }

        public static IAudioPlayer BackgroundPlayer { get; private set; }


        private IAudioManager _audioManager;
        private IAudioPlayer _player;

        public App()
        {
            InitializeComponent();

         
            _audioManager = AudioManager.Current;

         
            PlayBackgroundMusic();

            MainPage = new AppShell();

        
            Shell.Current.GoToAsync("//MainPage");

       
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

            Database = new UserDatabase(dbPath);
        }

        private async void PlayBackgroundMusic()
        {
            try
            {
                // Só inicia se ainda não estiver a tocar
                if (BackgroundPlayer != null && BackgroundPlayer.IsPlaying)
                    return;

                var stream = await FileSystem.OpenAppPackageFileAsync("backgroundmusic.mp3");

                _player = _audioManager.CreatePlayer(stream);
                _player.Loop = true;
                _player.Play();

                BackgroundPlayer = _player; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tocar a música: {ex.Message}");
            }
        }



        public static MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}

