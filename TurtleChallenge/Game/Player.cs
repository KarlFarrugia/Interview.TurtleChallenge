using System;
using TurtleChallenge.Objects;

namespace TurtleChallenge
{
    public static class Player
    {
        /// <summary>
        /// The action method will perform one move on the using the turtle and the board. Keeping in mind that mutators
        /// are unattractive a new turtle object is returned after performing the required action. The rotation actions
        /// are done without checks. However, the move action has a preaction check that checks if the move will lead to
        /// an out of board exception.
        /// </summary>
        /// <param name="board">The board preloaded with the dimensions, mines and exit</param>
        /// <param name="turtle">The turtle which will perform one move. Preloaded with the current coordinates and the
        ///                      current direction</param>
        /// <param name="move">The move which the turtle must perform on the board</param>
        /// <returns>A new <see cref="Turtle"/> object which reflects the move</returns>
        /// <exception cref="Exception">Used when the turtle will attempt to go out of the board</exception>
        /// <exception cref="ArgumentOutOfRangeException">Default exception if an invalid move is encountered</exception>
        public static Turtle Action(Turtle turtle, Moves move)
        {
            switch (move)
            {
                case Moves.M:
                    if (Validation.ValidateTurtleMove(turtle))
                    {
                        return new Turtle(turtle.Move(), turtle.Direction);
                    }
                    else
                    {
                        throw new Exception("OUT OF BOARD");
                    }
                case Moves.L:
                    return new Turtle(turtle.TutleCoordinates(), turtle.RotateLeft());
                case Moves.R:
                    return new Turtle(turtle.TutleCoordinates(), turtle.RotateRight());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}