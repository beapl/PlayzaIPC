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


        }
    }
}
