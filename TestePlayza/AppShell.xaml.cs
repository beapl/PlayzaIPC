using Playza.Views;


namespace Playza
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MenuPage", typeof(Playza.Views.MenuPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            Routing.RegisterRoute("GamePage", typeof(GamePage));

        }
    }
}
