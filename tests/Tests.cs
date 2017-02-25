﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            //readonly string[] validMoves = new[] { "A8", "B7", "C6", "D5", "B3", "A2", "B1", "C2", "D3", "F5", "G6", "H7" };

            readonly Bishop bishop = new Bishop(new Position("E", 4));

            [Fact]
            public void THEN_the_Bishop_can_move_to_any_diagonal_space_from_their_position()
            {
                var moveIsValid = false;

                bishop.Move(new Position("A", 8), () => moveIsValid = true);

                Assert.True(moveIsValid);
            }

            [Fact]
            public void AND_the_Bishop_cannot_move_forwards()
            {
                var moveIsValid = false;

                bishop.Move(new Position("E", 5), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }


            [Fact]
            public void AND_the_Bishop_cannot_move_sideways()
            {
                var moveIsValid = false;

                bishop.Move(new Position("B", 4), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            [Fact]
            public void AND_any_other_space_is_not_valid()
            {
                var moveIsValid = false;

                bishop.Move(new Position("B", 7), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }
        }
    }

    public class Bishop
    {
        readonly Position _position;

        public Bishop(Position position)
        {
            _position = position;
        }

        public void Move(Position position, Action onMoveValid)
        {
            if (IsNotForwardsMove(position) &&
                IsNotSidewaysMove(position))
            {
                onMoveValid();
            }
        }

        bool IsNotForwardsMove(Position position)
        {
            return !_position.X.Equals(position.X);
        }

        bool IsNotSidewaysMove(Position position)
        {
            return !_position.Y.Equals(position.Y);
        }
    }

    public class Position
    {
        static readonly IDictionary<string, int> _xMapping = new Dictionary<string, int>{
            {"A",1},
            {"B",2},
            {"C",3},
            {"D",4},
            {"E",5},
            {"F",6},
            {"G",7},
            {"H",8}
        };

        public Position(string positionX, int positionY)
        {
            X = _xMapping[positionX];
            Y = positionY;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
