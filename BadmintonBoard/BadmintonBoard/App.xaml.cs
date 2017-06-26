using System.Threading;
using BadmintonBoard.Login;
using BadmintonBoard.Player;
using BadmintonBoard.Venue;
using Xamarin.Forms;

namespace BadmintonBoard
{
    public partial class App : Application
    {
        public static string UserId { get; set; }

        public static LoginViewModel StartPageViewModel { get; set; }

        public static Services.IAuthenticationService Authenticator { get; private set; }

        public static void InitializeAuthentication(Services.IAuthenticationService authenticator)
        {
            Authenticator = authenticator;
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
