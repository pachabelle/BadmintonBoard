using System;
using System.Collections.Generic;

namespace BadmintonBoard.Player
{
    public interface IActivePlayer
    {
        Player Player { get; }
        int LastRoundPlayed { get;}
        int NumberOfRoundsPlayed { get; }
        string CurrentCourt { get; }

        void UpdateRoundPlayed(int roundNumber, string court);
        bool CanPlay(IActivePlayer otherPlayer);
    }

    public class ActivePlayer : ObservableBase, IActivePlayer
    {
        private readonly List<Tuple<int, string>> m_playHistory = new List<Tuple<int, string>>();

        public ActivePlayer(Player player)
        {
            Player = player;
            LastRoundPlayed = 0;
            NumberOfRoundsPlayed = 0;
        }

        public Player Player { get; }

        public int LastRoundPlayed { get; private set; }

        public int NumberOfRoundsPlayed { get; private set; }

        public string CurrentCourt { get; private set; }

        public void UpdateRoundPlayed(int roundNumber, string court)
        {
            LastRoundPlayed = roundNumber;
            CurrentCourt = court;
            m_playHistory.Add(new Tuple<int, string>(roundNumber, court));
            NumberOfRoundsPlayed++;
        }

        public bool CanPlay(IActivePlayer otherPlayer)
        {
            return ((otherPlayer.Player.Grade - 1) == otherPlayer.Player.Grade) || ((Player.Grade + 1) == otherPlayer.Player.Grade);
        }
    }
}
