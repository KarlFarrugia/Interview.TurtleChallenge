using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects;
using TurtleChallenge.Objects.BoardComponents;

namespace TurtleChallenge.Game
{
    public static class ExecuteGame
    {
        /// <summary>
        /// This method is responsible for executing each sequence. All objects have already been preloaded. Each
        /// iteration will be fed to this method to execute the sequence of moves on the turtle. Keeping in mind that
        /// mutation is unattractive for functional languages my aim was to use recursion on the
        /// <see cref="ExecuteGame"/> until a base predicate is met. Upon reaching a base predicate a string is returned
        /// through each recursive call and returned as the method return. 
        /// </summary>
        /// <param name="board">The board preloaded with the dimensions, mines and exit</param>
        /// <param name="turtle">The turtle which will traverse the board. Preloaded with the starting coordinates
        ///                      and the starting direction</param>
        /// <param name="moves">A list of sequential moves each run must perform on the turtle</param>
        /// <returns>A string describing the fate of the turtle</returns>
        public static string Execute(Board board, Turtle turtle, IEnumerable<Moves> moves)
        {
            var coordinates = new Coordinates {CoordinateX = turtle.Coordinates.CoordinateX, CoordinateY = turtle.Coordinates.CoordinateY};
            
            if (board.IsMine(coordinates))
            {
                return "Mine hit!";
            }
            
            if (moves.Any())
            {
                return Execute(board, Player.PerformMove(turtle, moves.ElementAt(0)), moves.Skip(1));
            }
             
            return board.IsExit(coordinates) ? "Success!" : "Still in danger!";
        }
    }
}