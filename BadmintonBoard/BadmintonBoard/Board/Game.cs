using System.Collections.ObjectModel;
using BadmintonBoard.Player;
using BadmintonBoard.Venue;

namespace BadmintonBoard.Board
{
    public interface IGame
    {
        Court Court { get; }
    }

    public class Game : ObservableCollection<IActivePlayer>, IGame
    {
        public Game(Court court)
        {
            Court = court;
            Title = "Court: " + Court.Name;
        }

        public string Title { get; }

        public Court Court { get; }
    }
}
