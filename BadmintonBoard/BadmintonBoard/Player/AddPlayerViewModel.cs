using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BadmintonBoard.Player
{
    public class AddPlayerViewModel : ObservableBase
    {
        private readonly AddPlayer m_addPlayerPage;
        private string m_firstName;
        private string m_lastName;
        private PlayerGrade m_selectedGrade;

        public AddPlayerViewModel(AddPlayer addPlayerPage)
        {
            m_addPlayerPage = addPlayerPage;
            m_selectedGrade = PlayerGrade.C;
        }

        public string FirstName
        {
            get => m_firstName;
            set => SetProperty(ref m_firstName, value);
        }

        public string LastName
        {
            get => m_lastName;
            set => SetProperty(ref m_lastName, value);
        }

        public PlayerGrade SelectedGrade
        {
            get => m_selectedGrade;
            set => SetProperty(ref m_selectedGrade, value);
        }

        public IEnumerable<PlayerGrade> Grades => new List<PlayerGrade>{PlayerGrade.A, PlayerGrade.B, PlayerGrade.C, PlayerGrade.D, PlayerGrade.E};

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    //var existingPlayer = DataManager.DefaultManager.Players.ToList()
                    //                        .FirstOrDefault(p => string.Equals(p.FirstName, FirstName, StringComparison.OrdinalIgnoreCase) &&
                    //                                             string.Equals(p.LastName, LastName, StringComparison.OrdinalIgnoreCase));

                    //if (existingPlayer != null)
                    //{
                    //    await m_addPlayerPage.DisplayAlert("Error", "A player with this name already exists.", "Ok");
                    //    return;
                    //}

                    DataManagerHelper.AddPlayerAsync(new Player {FirstName = FirstName, LastName = LastName, Grade = (int)SelectedGrade, DisplayName = FirstName + " " + LastName});
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PopModalAsync();
                });
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
