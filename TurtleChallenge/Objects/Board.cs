using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects.BoardComponents;

namespace TurtleChallenge.Objects
{
    /// <summary>
    /// This class is used to create the board object where the <see cref="Turtle"/> will perform the sequence of
    /// <see cref="Moves"/>.
    /// </summary>
    public class Board
    {
        private int BoardWidth { get; set; }
        private int BoardLength { get; set; }
        private BoardBox[,] Box { get; set; }

        /// <summary>
        /// The CreateBoard method takes the dimensions of the board, the list of mine <see cref="Coordinates"/> and the
        /// exit <see cref="Coordinates"/>.
        /// </summary>
        /// <param name="boardSettings">This list contains the board length and width used to create the board area
        ///                             </param>
        /// <param name="mines">A list of mine <see cref="Coordinates"/></param>
        /// <param name="exit">The <see cref="Coordinates"/> of the exit object</param>
        public void CreateBoard(List<int> boardSettings, IEnumerable<Mine> mines, Exit exit)
        {
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            Box = new BoardBox[BoardWidth, BoardLength];

            foreach (var mine in mines) Box[mine.Coordinates.CoordinateX, mine.Coordinates.CoordinateY].Mine = true;
            
            Box[exit.Coordinates.CoordinateX, exit.Coordinates.CoordinateY].Exit = true;
            //default of boolean is false therefore no need to instantiate other values to false.
        }

        /// <summary>
        /// Checks if the provided <see cref="Coordinates"/> are a mine or not
        /// </summary>
        /// <param name="mine">The <see cref="Coordinates"/>  used to check if the mine is active</param>
        /// <returns>true if provided <see cref="Coordinates"/> are a mine else false</returns>
        public bool IsMine(Coordinates mine)
        {
            return Box[mine.CoordinateX, mine.CoordinateY].Mine;
        }
        
        /// <summary>
        /// Checks if the provided <see cref="Coordinates"/> is the exit or not
        /// </summary>
        /// <param name="exit">The <see cref="Coordinates"/>  used to check if the Box is the exit</param>
        /// <returns>true if provided <see cref="Coordinates"/> is the exit else false</returns>
        public bool IsExit(Coordinates exit)
        {
            return Box[exit.CoordinateX, exit.CoordinateY].Exit;
        }
    }
}