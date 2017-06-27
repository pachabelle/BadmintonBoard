using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.StartPageViewModel == null)
                App.StartPageViewModel = new LoginViewModel(this);

            BindingContext = App.StartPageViewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BgImage.Source = null;
        }
    }
}