using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Board
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Board : ContentPage
    {
        private BoardViewModel m_boardViewModel;

        public Board()
        {
            InitializeComponent();
        }

        public void SetViewModel(BoardViewModel viewModel)
        {
            m_boardViewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = m_boardViewModel;

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

        //private bool m_isRowEven;

        //private void Cell_OnAppearing(object sender, EventArgs e)
        //{
        //    //if (m_isRowEven)
        //    //{
        //    //    var viewCell = (ViewCell)sender;
        //    //    if (viewCell.View != null)
        //    //    {
        //    //        viewCell.View.BackgroundColor = Color.Gray;
        //    //    }
        //    //}

        //    //m_isRowEven = !m_isRowEven;
        //}
    }
}