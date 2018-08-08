using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects;

namespace TurtleChallenge
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
        /// The default constructor of the Board takes the dimensions of the board, the list of mine
        /// <see cref="Coordinates"/> and the exit <see cref="Coordinates"/> 
        /// </summary>
        /// <param name="boardSettings">This list contains the board length and width used to create the board area
        ///                             </param>
        /// <param name="Mines">A list of mine <see cref="Coordinates"/></param>
        /// <param name="Exit">The <see cref="Coordinates"/> of the exit object</param>
        public void CreateBoard(List<int> boardSettings, IEnumerable<Coordinates> Mines, Coordinates Exit)
        {
            BoardWidth = boardSettings.ElementAt(0);
            BoardLength = boardSettings.ElementAt(1);
            Box = new BoardBox[BoardWidth, BoardLength];

            for (var x = 0; x < BoardWidth; x++)
            {
                for (var y = 0; y < BoardLength; y++)
                {
                    Box[x, y] = new BoardBox{Mine = false, Exit = false};
                }
            }

            foreach (var Mine in Mines)
            {
                Box[Mine.CoordinateX, Mine.CoordinateY].Mine = true;
            }
            Box[Exit.CoordinateX, Exit.CoordinateY].Exit = true;
        }

        /// <summary>
        /// Checks if the provided <see cref="Coordinates"/> are a mine or not
        /// </summary>
        /// <param name="coordinates">The <see cref="Coordinates"/>  used to check if the mine is active</param>
        /// <returns>true if provided <see cref="Coordinates"/> are a mine else false</returns>
        public bool isMine(Coordinates coordinates)
        {
            return Box[coordinates.CoordinateX, coordinates.CoordinateY].Mine;
        }
        
        /// <summary>
        /// Checks if the provided <see cref="Coordinates"/> is the exit or not
        /// </summary>
        /// <param name="coordinates">The <see cref="Coordinates"/>  used to check if the Box is the exit</param>
        /// <returns>true if provided <see cref="Coordinates"/> is the exit else false</returns>
        public bool isExit(Coordinates coordinates)
        {
            return Box[coordinates.CoordinateX, coordinates.CoordinateY].Exit;
        }
    }
}