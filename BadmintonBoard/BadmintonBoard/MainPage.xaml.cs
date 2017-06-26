using Xamarin.Forms;

namespace BadmintonBoard
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel m_mainViewModel;
        
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(m_mainViewModel == null)
                m_mainViewModel = new MainViewModel(this);

            BindingContext = m_mainViewModel;
         }
    }
}
