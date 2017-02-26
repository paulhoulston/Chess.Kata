using System;
using Chess.Kata;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Castle_on_an_empty_chess_board
    {
        public class WHEN_the_castle_is_in_position_F3
        {
            readonly Castle _castle = new Castle(new Position("F3"));

            [Fact]
            public void THEN_I_cannot_move_on_to_my_current_position()
            {
                var moveIsValid = false;

                _castle.Move(new Position("F3"), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            // [Theory]
            // public void THEN_any_forward_or_backward_space_is_a_valid_move()
            // {

            // }

            // [Theory]
            // public void THEN_any_sideways_space_is_a_valid_move()
            // {

            // }

            // [Theory]
            // public void AND_all_other_spaces_are_invalid()
            // {

            // }
        }
    }

    public class Castle
    {
        readonly Position _position;

        public Castle(Position position)
        {
            _position = position;
        }

        public void Move(Position position, Action onValidMove)
        {
            if (IsNotCurrentSpace(position))
                onValidMove();
        }

        bool IsNotCurrentSpace(Position position)
        {
            return
                _position.X != position.X &&
                _position.Y != position.Y;
        }

    }
}