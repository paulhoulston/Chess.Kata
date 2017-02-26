using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            readonly Bishop bishop = new Bishop(new Position("E4"));

            [Theory]
            [InlineData("A8", true)]
            [InlineData("E5", false)]
            [InlineData("B5", false)]
            [InlineData("C7", false)]
            public void THEN_the_specified_move_is_valid(string position, bool isValid)
            {
                var moveIsValid = false;

                bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.Equal(isValid, moveIsValid);
            }
        }
    }

    public class Bishop
    {
        readonly Position _position;

        public Bishop(Position position)
        {
            _position = position;
        }

        public void Move(Position position, Action onMoveValid)
        {
            if (IsDiagonalMove(position))
            {
                onMoveValid();
            }
        }

        bool IsDiagonalMove(Position position)
        {
            var availableDiagonals = new List<dynamic>();

            GetDiagonalsInQuadrant(1, 1, availableDiagonals, (x, y) => x < 8 && y < 8);
            GetDiagonalsInQuadrant(-1, -1, availableDiagonals, (x, y) => x >= 0 && y >= 0);
            GetDiagonalsInQuadrant(-1, 1, availableDiagonals, (x, y) => x >= 0 && y < 8);
            GetDiagonalsInQuadrant(1, -1, availableDiagonals, (x, y) => x < 8 && y >= 0);

            return availableDiagonals.Any(entry => entry.X == position.X && entry.Y == position.Y);
        }

        void GetDiagonalsInQuadrant(int xSign, int ySign, List<dynamic> board, Func<int, int, bool> condition)
        {
            var x = _position.X;
            var y = _position.Y;
            while (condition(x, y))
            {
                board.Add(new { Y = y, X = x });

                x += xSign * 1;
                y += ySign * 1;
            }
        }
    }

    public class Position
    {
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

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
