using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BadmintonBoard.Player;
using BadmintonBoard.Venue;
using Xamarin.Forms;

namespace BadmintonBoard.Board
{
    public class BoardViewModel : ObservableBase
    {
        private readonly Board m_boardPage;
        private Venue.Venue m_venue;
        private readonly List<IActivePlayer> m_activePlayers = new List<IActivePlayer>();
        private readonly List<IRound> m_rounds = new List<IRound>();
        private readonly List<Court> m_courts = new List<Court>();
        private int m_roundNumber;
        
        private readonly ObservableCollection<IGame> m_currentGames = new ObservableCollection<IGame>();

        public BoardViewModel(Board boardPage, Venue.Venue venue)
        {
            m_venue = venue;
            m_boardPage = boardPage;
            //LoadPlayers();
            LoadCourts();
        }

        public string VenueName => m_venue.Name;

        public IList<IGame> CurrentGames => m_currentGames;

        public ICommand AddPlayersCommand
        {
            get
            {
                return new RelayCommand(async() =>
                {
                    var selectPlayerVm = new SelectPlayersViewModel(m_activePlayers.Select(a => a.Player).ToList());
                    selectPlayerVm.PlayersSelected += OnPlayersSelected;
                    var selectPlayerPage = new SelectPlayersPage();
                    selectPlayerPage.SetViewModel(selectPlayerVm);

                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PushModalAsync(selectPlayerPage);
                });
            }
        }

        private void OnPlayersSelected(object sender, SelectedPlayerEventArgs e)
        {
            var selectPlayerVm = sender as SelectPlayersViewModel;
            if(selectPlayerVm == null)
                return;

            selectPlayerVm.PlayersSelected -= OnPlayersSelected;

            foreach (var player in e.Players)
            {
                m_activePlayers.Add(new ActivePlayer(player));
            }
        }

        public ICommand CreateRoundCommand => new RelayCommand(CreateRound);

        public ICommand EndSessionCommand
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

        private async void LoadPlayers()
        {
            var players = await DataManager.DefaultManager.GetAllPlayersAync();
            foreach (var player in players)
            {
                var activePlayer = new ActivePlayer(player);
                m_activePlayers.Add(activePlayer);
            }
        }

        private async void LoadCourts()
        {
            var courts = await DataManager.DefaultManager.GetAllCourtsAync();
            foreach (var court in courts)
            {
                if(string.Equals(court.VenueId, m_venue.Id))
                    m_courts.Add(court);
            }
        }

        private void CreateRound()
        {
            m_currentGames.Clear();
            var remainingPlayers = m_activePlayers.ToList()
                                        .OrderBy(p => p.LastRoundPlayed)
                                        .ThenBy(p => p.NumberOfRoundsPlayed)
                                        .ThenBy(p => p.Player.Grade).ToList();
            m_roundNumber++;
           
            foreach (var court in m_courts)
            {
                var game = CreateGame(m_roundNumber, court, remainingPlayers);
                if (game == null)
                    break;

                m_currentGames.Add(game);
            }
            
            var round = new Round(m_roundNumber, m_currentGames);

            m_rounds.Add(round);
        }

        private IGame CreateGame(int roundNumder, Court court, IList<IActivePlayer> remainingPlayers)
        {
            if (!remainingPlayers.Any())
                return null;

            var maxPlayers = remainingPlayers.Count >= court.NumberOfPlayers
                ? court.NumberOfPlayers
                : court.NumberOfPlayers > 2 && remainingPlayers.Count >= 2
                    ? 2
                    : 0;

            if (maxPlayers == 0)
                return null;

            var gamePlayers = ChoosePlayers(maxPlayers, remainingPlayers);

            var game = new Game(court);
            foreach (var player in gamePlayers)
            {
                player.UpdateRoundPlayed(roundNumder, court.Name);
                game.Add(player);
            }

            return game;
        }

        private IList<IActivePlayer> ChoosePlayers(int maxPlayers, IList<IActivePlayer> remainingPlayers)
        {
            var chosenPlayers = new List<IActivePlayer>();
            
            var firstPlayer = remainingPlayers.FirstOrDefault();
            chosenPlayers.Add(firstPlayer);
            remainingPlayers.Remove(firstPlayer);

            var playerCount = 1;
            while (playerCount < maxPlayers)
            {
                var nextPlayer = FindNextPlayer(chosenPlayers, remainingPlayers);
                chosenPlayers.Add(nextPlayer);
                remainingPlayers.Remove(nextPlayer);
                playerCount++;
            }

            return chosenPlayers;
        }

        private IActivePlayer FindNextPlayer(IList<IActivePlayer> comparisonPlayers, IList<IActivePlayer> remainingPlayers)
        {
            var playablePlayer = remainingPlayers.FirstOrDefault(p => comparisonPlayers.Any(p.CanPlay));
            return playablePlayer ?? remainingPlayers.FirstOrDefault();
        }
    }
}
