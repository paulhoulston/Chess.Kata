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
            [InlineData("A8")]
            [InlineData("B1")]
            [InlineData("B7")]
            [InlineData("C2")]
            [InlineData("C6")]
            [InlineData("D3")]
            [InlineData("D5")]
            [InlineData("F3")]
            [InlineData("F5")]
            [InlineData("G2")]
            [InlineData("G6")]
            [InlineData("H1")]
            [InlineData("H7")]
            public void THEN_any_diagonal_space_is_valid(string position)
            {
                var moveIsValid = false;

                bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.True(moveIsValid);
            }

            [Theory]
            [InlineData("A4")]
            [InlineData("B4")]
            [InlineData("C4")]
            [InlineData("D4")]
            [InlineData("F4")]
            [InlineData("G4")]
            [InlineData("H4")]
            public void AND_any_sideways_space_is_not_valid(string position)
            {
                var moveIsValid = false;

                bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            [Theory]
            [InlineData("E1")]
            [InlineData("E2")]
            [InlineData("E3")]
            [InlineData("E5")]
            [InlineData("E6")]
            [InlineData("E7")]
            [InlineData("E8")]
            public void AND_any_up_or_down_space_is_not_valid(string position)
            {
                var moveIsValid = false;

                bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            [Fact]
            public void AND_moving_on_to_oneself_is_not_a_valid_move()
            {
                var moveIsValid = false;

                bishop.Move(new Position("E4"), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

                        [Theory]
            [InlineData("A1", false)]
            [InlineData("A2", false)]
            [InlineData("A3", false)]
            [InlineData("A5", false)]
            [InlineData("A6", false)]
            [InlineData("A7", false)]
            [InlineData("B2", false)]
            [InlineData("B3", false)]
            [InlineData("B5", false)]
            [InlineData("B6", false)]
            [InlineData("B8", false)]
            [InlineData("C1", false)]
            [InlineData("C3", false)]
            [InlineData("C5", false)]
            [InlineData("C7", false)]
            [InlineData("C8", false)]
            [InlineData("D1", false)]
            [InlineData("D2", false)]
            [InlineData("D6", false)]
            [InlineData("D7", false)]
            [InlineData("D8", false)]
            [InlineData("F1", false)]
            [InlineData("F2", false)]
            [InlineData("F6", false)]
            [InlineData("F7", false)]
            [InlineData("F8", false)]
            [InlineData("G1", false)]
            [InlineData("G3", false)]
            [InlineData("G5", false)]
            [InlineData("G7", false)]
            [InlineData("G8", false)]
            [InlineData("H2", false)]
            [InlineData("H3", false)]
            [InlineData("H5", false)]
            [InlineData("H6", false)]
            [InlineData("H8", false)]
            public void AND_any_other_move_is_not_valid(string position, bool isValid)
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
