using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Player
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPlayer : ContentPage
    {
        private ManagePlayerViewModel m_managePlayerViewModel;

        public ManagerPlayer()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_managePlayerViewModel = new ManagePlayerViewModel(this);

            BindingContext = m_managePlayerViewModel;

            //MessagingCenter.Subscribe<MainPage, LandingResultType>(this, "ActivityUpdate", (sender, arg) =>
            //{
            //    string title = arg.ToString();
            //    string message = (arg == LandingResultType.Landed) ? "The Eagle has landed!" : "That's going to leave a mark!";
            //    if (arg == LandingResultType.Kaboom) App.ViewModel.ShakeLandscapeAsync(this);

            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        this.DisplayAlert(title, message, "OK");
            //        App.ViewModel.ResetLanding();
            //    });
            //});
        }
    }
}