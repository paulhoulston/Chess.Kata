using System;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            //readonly string[] validMoves = new[] { "A8", "B7", "C6", "D5", "B3", "A2", "B1", "C2", "D3", "F5", "G6", "H7" };

            [Fact]
            public void THEN_the_Bishop_can_move_to_any_diagonal_space_from_their_position()
            {
                var moveIsValid = false;

                var bishop = new Bishop("E", "4");

                bishop.Move("A", "8", () => moveIsValid = true);

                Assert.True(moveIsValid);
            }

            [Fact]
            public void AND_the_Bishop_cannot_move_forwards()
            {
                var moveIsValid = false;

                var bishop = new Bishop("E", "4");

                bishop.Move("E", "5", () => moveIsValid = true);

                Assert.False(moveIsValid);
            }


            [Fact]
            public void AND_the_Bishop_cannot_move_sideways()
            {
                var moveIsValid = false;

                var bishop = new Bishop("E", "4");

                bishop.Move("B", "4", () => moveIsValid = true);

                Assert.False(moveIsValid);
            }


        }
    }

    public class Bishop
    {
        readonly string _positionX;
        readonly string _positionY;

        public Bishop(string positionX, string positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public void Move(string positionX, string positionY, Action onMoveValid)
        {
            if (!IsForwardsMove(positionX) &&
                !IsSidewaysMove(positionY))
            {
                onMoveValid();
            }
        }

        bool IsForwardsMove(string positionX)
        {
            return _positionX.Equals(positionX);
        }

        bool IsSidewaysMove(string positionY)
        {
            return _positionY.Equals(positionY);
        }
    }
}
