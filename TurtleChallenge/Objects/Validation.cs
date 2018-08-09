using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects.BoardComponents;

namespace TurtleChallenge.Objects
{
    /// <summary>
    /// A class used to validate the game settings and movements.
    /// </summary>
    public class Validation
    {
        private static int BoardLength { get; set; }
        private static int BoardWidth { get; set; }
        
        /// <summary>
        /// The validation constructor takes the board dimensions as a parameter. The constructor checks the dimensions
        /// are not less than 0.
        /// </summary>
        /// <param name="boardSettings">a list of two integers containing the width and length of the board</param>
        /// <exception cref="Exception">Width or(and) Length less than 0</exception>
        public void ValidateBoard (List<int> boardSettings)
        {
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            //checks board settings are both greater than 0
            if (BoardLength < 0 || BoardWidth < 0) throw new Exception("Invalid board parameters");           
        }

        /// <summary>
        /// This method is used to check that the object's coordinates (be it a mine or an exit) lies on the board.
        /// </summary>
        /// <param name="coordinates">The coordinates of the object to be checked</param>
        /// <exception cref="IndexOutOfRangeException">Coordinates are out of the board</exception>
        public void InBoardValidation(Coordinates coordinates)
        {
            //checks that coordinates are within the board perimeter
            if (coordinates.CoordinateX >= BoardWidth 
                || coordinates.CoordinateY >= BoardLength
                || coordinates.CoordinateX < 0 
                || coordinates.CoordinateY < 0)
                throw new IndexOutOfRangeException("Object out of board");            
        }

        /// <summary>
        /// Given that an exit is the goal it cannot be a mine. A check is made to ensure that this situation never
        /// occurs
        /// </summary>
        /// <param name="board">The fully constructed <see cref="Board"/></param>
        /// <param name="exit">The <see cref="Exit.Coordinates"/> on the <see cref="Board"/></param>
        /// <exception cref="Exception">Exit is a mine</exception>
        public void IsExitAMine(Board board, Exit exit)
        {
            //checks that an exit is not also a mine
            if (board.IsExit(exit.Coordinates) == board.IsMine(exit.Coordinates))
                throw new Exception("Exit cannot be a mine");             
        }
        
        /// <summary>
        /// Before moving the <see cref="Turtle"/> it would be attractive to know if such a move is possible in the
        /// first place. This method checks if the current <see cref="Turtle"/> <see cref="Coordinates"/> and
        /// <see cref="Direction"/> allow the <see cref="Turtle"/> to move.
        /// </summary>
        /// <param name="turtle">The <see cref="Turtle"/> object to check if it can move on the board</param>
        /// <returns>true if <see cref="Turtle"/> can move and false if it cannot</returns>
        /// <exception cref="ArgumentOutOfRangeException">Default Exception if case does not match</exception>
        public static bool ValidateTurtleMove(Turtle turtle)
        {
            switch (turtle.Direction)
            {
                case Direction.N:
                    return turtle.Coordinates.CoordinateY != 0;
                case Direction.E:
                    return turtle.Coordinates.CoordinateX != BoardWidth;
                case Direction.S:
                    return turtle.Coordinates.CoordinateY != BoardLength;
                case Direction.W:
                    return turtle.Coordinates.CoordinateX != 0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}