using System;

namespace Chess.Kata.Pieces
{
    public class SamePositionValidator : IValidateMoves
    {
        readonly Position _currentPosition;

        public SamePositionValidator(Position currentPosition)
        {
            _currentPosition = currentPosition;
        }

        public void IsValid(Position newPosition, Action onValid)
        {
            if (_currentPosition.X != newPosition.X &&
                _currentPosition.Y != newPosition.Y)
            {
                onValid();
            }
        }
    }
}