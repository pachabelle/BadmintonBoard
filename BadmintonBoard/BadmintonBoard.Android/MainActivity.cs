using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using BadmintonBoard.Services;
using BadmintonBoard.Player;


namespace BadmintonBoard.Droid
{
    [Activity(Label = "BadmintonBoard", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticationService
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);

            SQLitePCL.Batteries.Init();
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            App.InitializeAuthentication((IAuthenticationService)this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        MobileServiceUser user = null;

        public async Task<bool> SignInAsync()
        {
            bool isSuccessful = false;

            try
            {
                user = await DataManager.DefaultManager.CurrentClient.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount);
                isSuccessful = user != null;
            }
            catch { }

            return isSuccessful;
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

