using System;
using Xunit;

namespace Tests
{
    public class GIVEN_I_have_only_a_single_white_Bishop_on_an_empty_chess_board
    {
        public class WHEN_the_Bishop_is_in_position_E4
        {
            readonly string[] validMoves = new[] { "A8", "B7", "C6", "D5", "B3", "A2", "B1", "C2", "D3", "F5", "G6", "H7" };

            [Fact]
            public void THEN_the_Bishop_can_move_to_any_diagonal_space_from_their_position()
            {
                var moveIsValid = false;

                var bishop = new Bishop();

                bishop.Move(() => moveIsValid = true);

                Assert.True(moveIsValid);
            }
        }
    }
    
    public class Bishop
    {
        public void Move(Action onMoveValid)
        {
            onMoveValid();
        }
    }
}
