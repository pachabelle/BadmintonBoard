using System.Collections.Generic;

namespace BadmintonBoard.Board
{
    public interface IRound
    {
        int Number { get; }

        IList<IGame> Games { get; }
    }

    public class Round : IRound 
    {
        public Round(int roundNumber, IEnumerable<IGame> games)
        {
            Number = roundNumber;
            Games = new List<IGame>(games);    
        }

        public int Number { get; }
        public IList<IGame> Games { get; }
    }
}
