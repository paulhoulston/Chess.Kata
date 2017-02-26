using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Kata.Pieces
{
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
}