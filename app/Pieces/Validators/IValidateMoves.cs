using System;

namespace Chess.Kata.Pieces
{
    public interface IValidateMoves
    {
        void IsValid(Position newPosition, Action onValid);
    }
}