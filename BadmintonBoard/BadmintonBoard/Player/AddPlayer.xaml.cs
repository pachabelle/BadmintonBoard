using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Player
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlayer : ContentPage
    {
        private AddPlayerViewModel m_addPlayerView;

        public AddPlayer()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_addPlayerView = new AddPlayerViewModel(this);

            BindingContext = m_addPlayerView;

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