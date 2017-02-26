using System;
using Chess.Kata;
using Chess.Kata.Pieces;
using Chess.Kata.Pieces.Validators;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Castle_on_an_empty_chess_board
    {
        public class WHEN_the_castle_is_in_position_F3
        {
            [Fact]
            public void THEN_I_cannot_move_on_to_my_current_position()
            {
                var moveIsValid = false;
                var castle = new Castle(new Position("F3"), () => moveIsValid = true);
                castle.Move(new Position("F3"));
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

    public class Castle : IAmAChessPiece
    {
        readonly Position _position;
        readonly ValidatorCollection _validators;

        public Castle(Position currentPosition, Action onValidMove)
        {
            _position = currentPosition;
            _validators = new ValidatorCollection(
                onValidMove,
                new SamePositionValidator(currentPosition));
        }

        public void Move(Position newPosition)
        {
            _validators.IsValid(newPosition);
        }
    }
}