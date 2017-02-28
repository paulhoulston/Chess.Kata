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
            //Console.WriteLine("SamePositionValidator::IsValid -> Starting position ({0},{1}), Desired position ({2},{3})", _currentPosition.X, _currentPosition.Y, newPosition.X, newPosition.Y);
            if (!(_currentPosition.X == newPosition.X && _currentPosition.Y == newPosition.Y))
            {
                onValid();
            }
        }
    }
}