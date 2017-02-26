using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Kata.Pieces.Validators
{
    public class DiagonalMoveValidator : IValidateMoves
    {
        readonly Position _currentPosition;

        public DiagonalMoveValidator(Position position)
        {
            _currentPosition = position;
        }

        public void IsValid(Position newPosition, Action onValid)
        {

            var availableDiagonals = new List<dynamic>();

            GetDiagonalsInQuadrant(1, 1, availableDiagonals, (x, y) => x < 8 && y < 8);
            GetDiagonalsInQuadrant(-1, -1, availableDiagonals, (x, y) => x >= 0 && y >= 0);
            GetDiagonalsInQuadrant(-1, 1, availableDiagonals, (x, y) => x >= 0 && y < 8);
            GetDiagonalsInQuadrant(1, -1, availableDiagonals, (x, y) => x < 8 && y >= 0);

            if (availableDiagonals.Any(entry => entry.X == newPosition.X && entry.Y == newPosition.Y))
            {
                onValid();
            }
        }

        void GetDiagonalsInQuadrant(int xSign, int ySign, List<dynamic> board, Func<int, int, bool> condition)
        {
            var x = _currentPosition.X;
            var y = _currentPosition.Y;
            while (condition(x, y))
            {
                board.Add(new { Y = y, X = x });

                x += xSign * 1;
                y += ySign * 1;
            }
        }
    }
}