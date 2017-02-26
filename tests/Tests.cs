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
            [InlineData("A1", false)]
            [InlineData("A2", false)]
            [InlineData("A3", false)]
            [InlineData("A4", false)]
            [InlineData("A5", false)]
            [InlineData("A6", false)]
            [InlineData("A7", false)]
            [InlineData("A8", true)]
            [InlineData("B1", true)]
            [InlineData("B2", false)]
            [InlineData("B3", false)]
            [InlineData("B4", false)]
            [InlineData("B5", false)]
            [InlineData("B6", false)]
            [InlineData("B7", true)]
            [InlineData("B8", false)]
            [InlineData("C1", false)]
            [InlineData("C2", true)]
            [InlineData("C3", false)]
            [InlineData("C4", false)]
            [InlineData("C5", false)]
            [InlineData("C6", true)]
            [InlineData("C7", false)]
            [InlineData("C8", false)]
            [InlineData("D1", false)]
            [InlineData("D2", false)]
            [InlineData("D3", true)]
            [InlineData("D4", false)]
            [InlineData("D5", true)]
            [InlineData("D6", false)]
            [InlineData("D7", false)]
            [InlineData("D8", false)]
            [InlineData("E1", false)]
            [InlineData("E2", false)]
            [InlineData("E3", false)]
            [InlineData("E4", false)]
            [InlineData("E5", false)]
            [InlineData("E6", false)]
            [InlineData("E7", false)]
            [InlineData("E8", false)]
            [InlineData("F1", false)]
            [InlineData("F2", false)]
            [InlineData("F3", true)]
            [InlineData("F4", false)]
            [InlineData("F5", true)]
            [InlineData("F6", false)]
            [InlineData("F7", false)]
            [InlineData("F8", false)]
            [InlineData("G1", false)]
            [InlineData("G2", true)]
            [InlineData("G3", false)]
            [InlineData("G4", false)]
            [InlineData("G5", false)]
            [InlineData("G6", true)]
            [InlineData("G7", false)]
            [InlineData("G8", false)]
            [InlineData("H1", true)]
            [InlineData("H2", false)]
            [InlineData("H3", false)]
            [InlineData("H4", false)]
            [InlineData("H5", false)]
            [InlineData("H6", false)]
            [InlineData("H7", true)]
            [InlineData("H8", false)]
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
            if (IsNotCurrentSpace(position) &&
                IsDiagonalMove(position))
            {
                onMoveValid();
            }
        }

        bool IsNotCurrentSpace(Position position)
        {
            return
                _position.X != position.X &&
                _position.Y != position.Y;
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
