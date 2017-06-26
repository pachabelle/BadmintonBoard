using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Board
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPlayersPage : ContentPage
    {
        private SelectPlayersViewModel m_viewModel;

        public SelectPlayersPage()
        {
            InitializeComponent();
        }

        public void SetViewModel(SelectPlayersViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = m_viewModel;
        }
    }
}