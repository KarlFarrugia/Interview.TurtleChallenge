using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects;
using TurtleChallenge.Objects.BoardComponents;

namespace TurtleChallenge.Game
{
    /// <summary>
    /// This class is responsible for executing the list of games
    /// </summary>
    public class ExecuteGame
    {
        private int numberOfGames { set; get; }
        public ExecuteGame(IEnumerable<string> games)
        {
            numberOfGames = games.Count();
        }

        /// <summary>
        /// This method is responsible for iterating through the list of games and printing the results of each game to
        /// console.
        /// </summary>
        /// <param name="board">The board preloaded with the dimensions, mines and exit</param>
        /// <param name="turtle">The turtle which will traverse the board. Preloaded with the starting coordinates
        ///                      and the starting direction</param>
        /// <param name="moves">A list of runs that must perform on the turtle</param>
        public void ExecuteGames(Board board, Turtle turtle, IEnumerable<string> games)
        {
            //Base Case if no more moves are left to be played
            if (!games.Any()) return;
            IEnumerable<Moves> sequence = games.
                ElementAt(0).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
            Console.WriteLine("Sequence " + (numberOfGames - games.Count() + 1) + ": "
                              + Execute(board, turtle, sequence));
            ExecuteGames(board, turtle, games.Skip(1));
        }
        
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
            //Checks if the current turtle poisition is on a mine
            if (board.IsMine(turtle.Coordinates)) return "Mine hit!";          
            
            //Base Case if no more moves are left to be played
            if (moves.Any()) return Execute(board, Player.PerformMove(turtle, moves.ElementAt(0)), moves.Skip(1));
                         
            //Checks if the end position is an exit otherwise turtle is still in danger
            return board.IsExit(turtle.Coordinates) ? "Success!" : "Still in danger!";
        }
    }
}