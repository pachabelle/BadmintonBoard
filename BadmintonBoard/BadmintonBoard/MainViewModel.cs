using System.Linq;
using System.Windows.Input;
using BadmintonBoard.Board;
using BadmintonBoard.Player;
using BadmintonBoard.Venue;
using Xamarin.Forms;

namespace BadmintonBoard
{
    public class MainViewModel : ObservableBase
    {
        private MainPage m_mainPage;

        public MainViewModel(MainPage startPage)
        {
            StartPage = startPage;
        }
        
        public MainPage StartPage
        {
            get => m_mainPage;
            set => SetProperty(ref m_mainPage, value);
        }

        public ICommand CreateBoardCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var venues = await DataManager.DefaultManager.GetAllVenuesAync();
                    if (!venues.Any())
                    {
                        await m_mainPage.DisplayAlert("", "You must create a venue before you can create a board.", "Ok");
                        return;
                    }

                    var players = await DataManager.DefaultManager.GetAllPlayersAync();
                    if (players.Count < 2)
                    {
                        await m_mainPage.DisplayAlert("", "You do not have enought players to create a board.", "Ok");
                        return;
                    }

                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PushModalAsync(new SelectVenuePage());
                });
            }
        }

        public ICommand ManagePlayersCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PushModalAsync(new ManagerPlayer());
                });
            }
        }

        public ICommand ManageVenuesCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PushModalAsync(new ManageVenuesPage());
                });
            }
        }
    }
}
