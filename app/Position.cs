using System.Collections.Generic;

namespace Chess.Kata
{
    public class Position
    {
        public readonly int X;
        public readonly int Y;

        static readonly IDictionary<char, int> _xMapping = new Dictionary<char, int>{
            {'A',0},
            {'B',1},
            {'C',2},
            {'D',3},
            {'E',4},
            {'F',5},
            {'G',6},
            {'H',7}
        };

        public Position(string position)
        {
            X = _xMapping[position[0]];
            Y = int.Parse(position[1].ToString()) - 1;
        }
    }
}