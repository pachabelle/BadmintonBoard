using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BadmintonBoard.Player;
using Xamarin.Forms;

namespace BadmintonBoard.Board
{
    public class SelectablePlayer : ObservableBase
    {
        private bool m_isSelected;

        public SelectablePlayer(Player.Player player)
        {
            Player = player;
        }

        public Player.Player Player { get; }

        public bool IsSelected
        {
            get => m_isSelected;
            set => SetProperty(ref m_isSelected, value);
        }
    }

    public class SelectedPlayerEventArgs : EventArgs
    {
        public SelectedPlayerEventArgs(IEnumerable<Player.Player> players)
        {
            Players = players;
        }

        public IEnumerable<Player.Player> Players { get; }
    }

    public class SelectPlayersViewModel : ObservableBase
    {
        private readonly IEnumerable<Player.Player> m_activePlayers;
        private readonly ObservableCollection<SelectablePlayer> m_players = new ObservableCollection<SelectablePlayer>();

        public SelectPlayersViewModel(IEnumerable<Player.Player> activePlayers)
        {
            m_activePlayers = activePlayers;
            LoadPlayers();
        }

        public event EventHandler<SelectedPlayerEventArgs> PlayersSelected;

        public IList<SelectablePlayer> Players => m_players;

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(async () =>
                    {
                        var selectedPlayers = m_players.Where(p => p.IsSelected).ToList();
                        if (selectedPlayers.Any())
                        {
                            PlayersSelected?.Invoke(this,
                                new SelectedPlayerEventArgs(selectedPlayers.Select(p => p.Player)));
                        }

                        NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                        if (mainPage != null)
                            await mainPage.Navigation.PopModalAsync();
                    }
                );
            }
        }

        private async void LoadPlayers()
        {
            var allPlayers = await DataManager.DefaultManager.GetAllPlayersAync();
            var inactivePlayers = allPlayers.Where(p => !m_activePlayers.Any(ap => string.Equals(ap.Id, p.Id))).ToList();

            m_players.Clear();
            foreach (var player in inactivePlayers)
            {
                m_players.Add(new SelectablePlayer(player));
            }
        }
    }
}
