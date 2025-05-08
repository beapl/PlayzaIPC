using Android.Media;
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
            Routing.RegisterRoute("RegisterPage", typeof(Playza.Views.RegisterPage));
            Routing.RegisterRoute("GamePage", typeof(Playza.Views.GamePage));
            Routing.RegisterRoute("MiniGamesPage", typeof(Playza.Views.MiniGamesPage));
            Routing.RegisterRoute("MiniJogo1", typeof(Playza.Views.MiniJogo1));
            Routing.RegisterRoute("MiniJogo2", typeof(Playza.Views.MiniJogo2));
            Routing.RegisterRoute("MiniJogo3", typeof(Playza.Views.MiniJogo3));
            Routing.RegisterRoute("MiniJogo4", typeof(Playza.Views.MiniJogo4));

        }
    }
}
