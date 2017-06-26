using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Board
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectVenuePage : ContentPage
    {
        public SelectVenuePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new SelectVenueViewModel(this);
        }
    }
}