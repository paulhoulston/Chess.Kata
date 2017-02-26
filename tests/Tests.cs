using Chess.Kata;
using Chess.Kata.Pieces;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            readonly Bishop _bishop = new Bishop(new Position("E4"));

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

                _bishop.Move(new Position(position), () => moveIsValid = true);

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

                _bishop.Move(new Position(position), () => moveIsValid = true);

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

                _bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            [Fact]
            public void AND_moving_on_to_oneself_is_not_a_valid_move()
            {
                var moveIsValid = false;

                _bishop.Move(new Position("E4"), () => moveIsValid = true);

                Assert.False(moveIsValid);
            }

            [Theory]
            [InlineData("A1", false)]
            [InlineData("A2", false)]
            [InlineData("A3", false)]
            [InlineData("A5", false)]
            [InlineData("A6", false)]
            [InlineData("A7", false)]
            [InlineData("B2", false)]
            [InlineData("B3", false)]
            [InlineData("B5", false)]
            [InlineData("B6", false)]
            [InlineData("B8", false)]
            [InlineData("C1", false)]
            [InlineData("C3", false)]
            [InlineData("C5", false)]
            [InlineData("C7", false)]
            [InlineData("C8", false)]
            [InlineData("D1", false)]
            [InlineData("D2", false)]
            [InlineData("D6", false)]
            [InlineData("D7", false)]
            [InlineData("D8", false)]
            [InlineData("F1", false)]
            [InlineData("F2", false)]
            [InlineData("F6", false)]
            [InlineData("F7", false)]
            [InlineData("F8", false)]
            [InlineData("G1", false)]
            [InlineData("G3", false)]
            [InlineData("G5", false)]
            [InlineData("G7", false)]
            [InlineData("G8", false)]
            [InlineData("H2", false)]
            [InlineData("H3", false)]
            [InlineData("H5", false)]
            [InlineData("H6", false)]
            [InlineData("H8", false)]
            public void AND_any_other_move_is_not_valid(string position, bool isValid)
            {
                var moveIsValid = false;

                _bishop.Move(new Position(position), () => moveIsValid = true);

                Assert.Equal(isValid, moveIsValid);
            }
        }
    }
}
