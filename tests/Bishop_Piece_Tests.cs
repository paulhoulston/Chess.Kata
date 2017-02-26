using Chess.Kata;
using Chess.Kata.Pieces;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            [Theory]
            [InlineData("A8")]
            [InlineData("B1")]
            [InlineData("B7")]
            [InlineData("C2")]
            [InlineData("C6")]
            [InlineData("D3")]
            [InlineData("D5")]
            [InlineData("F3")]
            [InlineData("F5")]
            [InlineData("G2")]
            [InlineData("G6")]
            [InlineData("H1")]
            [InlineData("H7")]
            public void THEN_any_diagonal_space_is_valid(string position)
            {
                var moveIsValid = false;
                var bishop = new Bishop(new Position("E4"), () => moveIsValid = true);
                bishop.Move(new Position(position));

                Assert.True(moveIsValid);
            }

            [Theory]
            [InlineData("A4")]
            [InlineData("B4")]
            [InlineData("C4")]
            [InlineData("D4")]
            [InlineData("F4")]
            [InlineData("G4")]
            [InlineData("H4")]
            public void AND_any_sideways_space_is_not_valid(string position)
            {
                var moveIsValid = false;
                var bishop = new Bishop(new Position("E4"), () => moveIsValid = true);
                bishop.Move(new Position(position));
                Assert.False(moveIsValid);
            }

            [Theory]
            [InlineData("E1")]
            [InlineData("E2")]
            [InlineData("E3")]
            [InlineData("E5")]
            [InlineData("E6")]
            [InlineData("E7")]
            [InlineData("E8")]
            public void AND_any_up_or_down_space_is_not_valid(string position)
            {
                var moveIsValid = false;
                var bishop = new Bishop(new Position("E4"), () => moveIsValid = true);
                bishop.Move(new Position(position));
                Assert.False(moveIsValid);
            }

            [Fact]
            public void AND_moving_on_to_oneself_is_not_a_valid_move()
            {
                var moveIsValid = false;
                var bishop = new Bishop(new Position("E4"), () => moveIsValid = true);
                bishop.Move(new Position("E4"));
                Assert.False(moveIsValid);
            }

            [Theory]
            [InlineData("A1")]
            [InlineData("A2")]
            [InlineData("A3")]
            [InlineData("A5")]
            [InlineData("A6")]
            [InlineData("A7")]
            [InlineData("B2")]
            [InlineData("B3")]
            [InlineData("B5")]
            [InlineData("B6")]
            [InlineData("B8")]
            [InlineData("C1")]
            [InlineData("C3")]
            [InlineData("C5")]
            [InlineData("C7")]
            [InlineData("C8")]
            [InlineData("D1")]
            [InlineData("D2")]
            [InlineData("D6")]
            [InlineData("D7")]
            [InlineData("D8")]
            [InlineData("F1")]
            [InlineData("F2")]
            [InlineData("F6")]
            [InlineData("F7")]
            [InlineData("F8")]
            [InlineData("G1")]
            [InlineData("G3")]
            [InlineData("G5")]
            [InlineData("G7")]
            [InlineData("G8")]
            [InlineData("H2")]
            [InlineData("H3")]
            [InlineData("H5")]
            [InlineData("H6")]
            [InlineData("H8")]
            public void AND_any_other_move_is_not_valid(string position)
            {
                var moveIsValid = false;
                var bishop = new Bishop(new Position("E4"), () => moveIsValid = true);
                bishop.Move(new Position(position));
                Assert.False(moveIsValid);
            }
        }
    }
}
