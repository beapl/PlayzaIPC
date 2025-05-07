using Playza;
using Playza.Services;

namespace Playza
{
    public partial class App : Application
    {
        private readonly UsageTracker _usageTracker = new UsageTracker();

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Shell.Current.GoToAsync("//MainPage");

        }    
        public static MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }


    }
