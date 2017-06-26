using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using BadmintonBoard.Player;
using BadmintonBoard.Services;

namespace BadmintonBoard.UWP
{
    public sealed partial class MainPage : IAuthenticationService
    {
        public MainPage()
        {
            this.InitializeComponent();
            SQLitePCL.Batteries.Init();
            //Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            BadmintonBoard.App.InitializeAuthentication((IAuthenticationService)this);
            LoadApplication(new BadmintonBoard.App());
        }

        MobileServiceUser user = null;

        public async Task<bool> SignInAsync()
        {
            bool successful = false;

            try
            {
                user = await DataManager.DefaultManager.CurrentClient.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                successful = user != null;
            }
            catch { }

            return successful;
        }

        public async Task<bool> SignOutAsync()
        {
            bool isSuccessful = false;

            try
            {
                await DataManager.DefaultManager.CurrentClient.LogoutAsync();
                isSuccessful = true;
            }
            catch { }

            return isSuccessful;
        }
    }
}
