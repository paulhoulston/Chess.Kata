using System;
using Chess.Kata.Pieces.Validators;

namespace Chess.Kata.Pieces
{
    public class Bishop : IAmAChessPiece
    {
        readonly Position _currentPosition;
        readonly ValidatorCollection _validators;

        public Bishop(Position currentPosition, Action onMoveValid)
        {
            _currentPosition = currentPosition;
            _validators = new ValidatorCollection(
                onMoveValid,
                new SamePositionValidator(currentPosition),
                new DiagonalMoveValidator(currentPosition));
        }

        public void Move(Position newPosition)
        {
            _validators.IsValid(newPosition);
        }
    }
}