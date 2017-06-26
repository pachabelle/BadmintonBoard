using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BadmintonBoard.Venue
{
    public class CourtEventArgs : BackButtonPressedEventArgs
    {
        public CourtEventArgs(Court court)
        {
            Court = court;
        }

        public Court Court { get; }
    }

    public class AddCourtViewModel : ObservableBase
    {
        private readonly AddCourt m_addCourtPage;
        private int m_selectePlayerOption;
        private string m_name;

        public AddCourtViewModel(AddCourt addCourtPage)
        {
            m_addCourtPage = addCourtPage;
            m_selectePlayerOption = 4;
        }

        public event EventHandler<CourtEventArgs> CourtAdded;
        public event EventHandler AddCourtCancelled;

        public string Name
        {
            get => m_name;
            set => SetProperty(ref m_name, value);
        }

        public IList<int> PlayerOptions => new List<int> {2, 4};

        public int SelectPlayerOption
        {
            get => m_selectePlayerOption;
            set => SetProperty(ref m_selectePlayerOption, value);
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var court = new Court(Name, SelectPlayerOption);
                    CourtAdded?.Invoke(this, new CourtEventArgs(court));

                    await PopPage();
                });
            }
        }

        public ICommand CancelCommand => new RelayCommand(async () =>
            {
                AddCourtCancelled?.Invoke(this, EventArgs.Empty);
                await PopPage();
            });

        private static async Task PopPage()
        {
            NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
            if (mainPage != null)
                await mainPage.Navigation.PopModalAsync();
        }
    }
}
