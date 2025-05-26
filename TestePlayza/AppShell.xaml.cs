using Playza.Views;


namespace Playza
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MenuPage", typeof(Playza.Views.MenuPage));
            Routing.RegisterRoute("LoginPage", typeof(Playza.Views.LoginPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            Routing.RegisterRoute("Register1Page", typeof(Register1Page));
            Routing.RegisterRoute("Register2Page", typeof(Register2Page));
            Routing.RegisterRoute("ParentalControlPage", typeof(ParentalControlPage));
            Routing.RegisterRoute("ParentalSettingsPage", typeof(ParentalSettingsPage));
            Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
            Routing.RegisterRoute("MiniGamesPage", typeof(Playza.Views.MiniGamesPage));
            Routing.RegisterRoute("MiniJogo1", typeof(Playza.Views.MiniJogo1));
            Routing.RegisterRoute("MiniJogo2", typeof(Playza.Views.MiniJogo2));
            Routing.RegisterRoute("MiniJogo3", typeof(Playza.Views.MiniJogo3));
            Routing.RegisterRoute("MiniJogo4", typeof(Playza.Views.MiniJogo4));
            Routing.RegisterRoute("JourneyPage", typeof(Playza.Views.JourneyPage));
            Routing.RegisterRoute("CanvasPage", typeof(Playza.Views.CanvasPage));


        }
    }
}
