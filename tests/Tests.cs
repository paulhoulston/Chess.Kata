using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            [Fact]
            public void THEN_the_Bishop_can_move_to_any_diagonal_space_from_their_position()
            {
                var moveIsValid= false;

                Assert.True(moveIsValid);
            }
        }
    }
}
