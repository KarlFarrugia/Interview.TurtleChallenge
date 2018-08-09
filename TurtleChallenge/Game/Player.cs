using System;
using TurtleChallenge.Objects;
using TurtleChallenge.Objects.BoardComponents;

namespace TurtleChallenge.Game
{
    public static class Player
    {
        /// <summary>
        /// The action method will perform one move by the <see cref="Turtle"/> on the <see cref="Board"/>. Keeping in
        /// mind that mutators are unattractive a new turtle object is returned after performing the required action.
        /// The rotation actions are done without checks. However, the move action has a preaction check that checks if
        /// the move will lead to an out of board exception.
        /// </summary>
        /// <param name="turtle">The turtle which will perform one move. Preloaded with the current
        ///                     <see cref="Coordinates"/> and the current <see cref="Direction"/></param>
        /// <param name="move">The move which the turtle must perform on the board</param>
        /// <returns>A new <see cref="Turtle"/> object which reflects the move</returns>
        /// <exception cref="Exception">Used when the turtle will attempt to go out of the board</exception>
        /// <exception cref="ArgumentOutOfRangeException">Default exception if an invalid <see cref="Moves"/> is
        ///                                               encountered</exception>
        public static Turtle PerformMove(Turtle turtle, Moves move)
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
                    return new Turtle(turtle.Coordinates, turtle.RotateLeft());
                case Moves.R:
                    return new Turtle(turtle.Coordinates, turtle.RotateRight());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}