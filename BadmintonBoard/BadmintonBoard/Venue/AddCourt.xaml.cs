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
    public partial class AddCourt : ContentPage
    {
        private AddCourtViewModel m_addCourtViewModel;
        
        public AddCourt()
        {
            InitializeComponent();
        }

        public void SetBindingContext(AddCourtViewModel viewModel)
        {
            m_addCourtViewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = m_addCourtViewModel;
        }
    }
}