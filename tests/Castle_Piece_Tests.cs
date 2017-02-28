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

            [Theory]
            [InlineData("F1")]
            [InlineData("F2")]
            [InlineData("F4")]
            [InlineData("F5")]
            [InlineData("F6")]
            [InlineData("F7")]
            [InlineData("F8")]
            public void THEN_any_forward_or_backward_space_is_a_valid_move(string position)
            {
                var moveIsValid = false;
                var castle = new Castle(new Position("F3"), () => moveIsValid = true);
                castle.Move(new Position(position));
                Assert.True(moveIsValid);
            }

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
        readonly ValidatorCollection _validators;

        public Castle(Position currentPosition, Action onValidMove)
        {
            _validators = new ValidatorCollection(
                onValidMove,
                new SamePositionValidator(currentPosition),
                new ForwardsAndBackwardsMoveValidator(currentPosition));
        }

        public void Move(Position newPosition)
        {
            _validators.IsValid(newPosition);
        }
    }

    public class ForwardsAndBackwardsMoveValidator : IValidateMoves
    {
        readonly Position _currentPosition;

        public ForwardsAndBackwardsMoveValidator(Position currentPosition)
        {
            _currentPosition = currentPosition;
        }

        public void IsValid(Position newPosition, Action onValid)
        {
            // Console.WriteLine("ForwardsAndBackwardsMoveValidator::IsValid -> Starting position ({0},{1}), Desired position ({2},{3})", _currentPosition.X, _currentPosition.Y, newPosition.X, newPosition.Y);
            if (_currentPosition.X == newPosition.X)
            {
                onValid();
            }
        }
    }
}