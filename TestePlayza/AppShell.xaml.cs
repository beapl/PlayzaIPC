using Playza.Views;


namespace TestePlayza
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MenuPage", typeof(Playza.Views.MenuPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));

        }
    }
}
