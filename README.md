# Chess.Kata
The details and background of this kata can be found at https://www.red-gate.com/blog/building/code-kata-5-solid-chess. Details are

# The kata

Let’s get this clear: we’re not going to write a chess-playing AI in this kata. The idea is a bit more humble: to write a program that can work out valid moves for a set of chess pieces.

The purpose of this kata is to practise writing SOLID code. Use TDD, but concentrate on getting the code design right. So, refactor relentlessly at each step, using the SOLID principles as a way of examining your code.

I’ve laid out the steps you might take as follows.

Place a single white bishop anywhere on a chess board
Determine the set of squares to which the bishop can move (e.g. bishop, b6 -> {a5,c7,d8,a7,c5,d4,e3,f2,g1})
Add a white castle to the board and determine the squares to which it can move. Include a test where the bishop obstructs the castle’s movement
Now add a black bishop to the board, and determine the squares to which the white castle can move.  Include a test where the castle is able to take the black bishop
Now add a white queen and determine the squares to which she can move
Do the same for a white knight
Now add a white pawn and allow it to move forward one square (for now, ignore the two-square advance for a pawn’s first move). Include a test to ensure it is blocked by a black piece immediately in front of it
Allow the white pawn to capture a black piece by moving diagonally forward one square
Now allow a pawn to move either one or two spaces forward for its first move
Now allow a pawn to capture a piece en passant
Add a king and the ability to castle
Don’t aim to finish; there is almost certainly more here than can be done in the time. On the other hand, don’t spend too much the first two steps; try to get onto step 3 quickly, as this is the point where the kata becomes more interesting.
