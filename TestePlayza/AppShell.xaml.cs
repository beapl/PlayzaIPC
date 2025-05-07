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
            Routing.RegisterRoute("GamePage", typeof(GamePage));
            Routing.RegisterRoute("MiniGamesPage", typeof(MiniGamesPage));

        }
    }
}
