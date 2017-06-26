using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BadmintonBoard.Player
{
    public class ManagePlayerViewModel : ObservableBase
    {
        private readonly ManagerPlayer m_managePlayerPage;

        private readonly ObservableCollection<Player> m_playerItems = new ObservableCollection<Player>();

        public ManagePlayerViewModel(ManagerPlayer managePlayerPage)
        {
            m_managePlayerPage = managePlayerPage;
            LoadPlayers();
        }

        private async void LoadPlayers()
        {
            m_playerItems.Clear();

            var players = await DataManager.DefaultManager.GetAllPlayersAync();
            foreach (var player in players)
            {
                m_playerItems.Add(player);
            }
        }

        public IEnumerable<Player> Players => m_playerItems;

        public ICommand AddPlayerCommnd
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                    {
                        await mainPage.Navigation.PushModalAsync(new AddPlayer());
                    }
                });
            }
        }

        public ICommand FinishCommand
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
