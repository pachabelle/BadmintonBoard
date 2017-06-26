using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Venue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVenuePage : ContentPage
    {
        private AddVenueViewModel m_addVenueViewModel;

        public AddVenuePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (m_addVenueViewModel == null)
            {
                m_addVenueViewModel = new AddVenueViewModel(this);
                BindingContext = m_addVenueViewModel;
            }
        }
    }
}