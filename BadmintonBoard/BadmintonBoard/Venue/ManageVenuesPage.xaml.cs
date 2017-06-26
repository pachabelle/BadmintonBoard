using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadmintonBoard.Venue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageVenuesPage : ContentPage
    {
        private ManageVenuesViewModel m_manageCourtsViewModel;

        public ManageVenuesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            m_manageCourtsViewModel = new ManageVenuesViewModel(this);
            BindingContext = m_manageCourtsViewModel;
        }
    }
}