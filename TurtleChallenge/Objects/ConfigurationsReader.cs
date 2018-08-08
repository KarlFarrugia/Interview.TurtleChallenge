using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TurtleChallenge.Objects
{
    /// <summary>
    /// This class is used to read the configurations from the given file and construct the objects needed to carry out
    /// the games.
    /// </summary>
    public class ConfigurationsReader
    {
        public Board Board { get; private set; }
        public Turtle Turtle { get; private set; }
        public  IEnumerable<string> Games { get; private set; }
        private static Validation Validator { get; set; }

        /// <summary>
        /// Default constructor used for unit testing
        /// </summary>
        /// <param name="lines">A string containing the game settings</param>
        public ConfigurationsReader(string[] lines)
        {
            Board = ConfigureBoard(lines);            
            Turtle = CreateTurtle(lines.ElementAt(3));  
            Games = lines.Skip(4);
        }
        
        /// <summary>
        /// Receives a file as the parameter which will contain the game-settings needed throughout the game. This
        /// method will call the <see cref="ConfigureBoard"/> method to set up the board, the <see cref="CreateTurtle"/>
        /// to create the turtle object with its starting coordinates and its starting position and finally the
        /// <see cref="ReadMovements"/> to read the sequence of movements the user wants the turtle to perform on the
        /// board.
        /// </summary>
        /// <param name="file">A string containing the path to the game-settings file</param>
        public ConfigurationsReader(string file)
        {
             var lines = File.ReadAllLines(file);
             Board = ConfigureBoard(lines);            
             Turtle = CreateTurtle(lines.ElementAt(3));  
             Games = lines.Skip(4);
        }
        
        /// <summary>
        /// Takes a list of two integers and returns them as a <see cref="Coordinates"/> value.
        /// </summary>
        /// <param name="obj">The list of two integers needed to create the <see cref="Coordinates"/></param>
        /// <returns>The coordinates from the given list</returns>
        private static Coordinates ObjectCoordinates(IList<int> obj)
        {
            var objCoordinate = new Coordinates{CoordinateX = obj[0], CoordinateY = obj[1]};
            Validation.InBoardValidation(objCoordinate);
            return objCoordinate;
        }
        
        
        /// <summary>
        /// Takes a list of comma seperated mines and splits them into seperate mines to extract the
        /// <see cref="Coordinates"/> of each seperate mine. Each seperated mine will call the
        /// <see cref="ObjectCoordinates"/> to get the correct <see cref="Coordinates"/>.
        /// </summary>
        /// <param name="mines">A list of comma seperated mines</param>
        /// <returns>A list of mine <see cref="Coordinates"/> </returns>
        /// 
        private static IEnumerable<Coordinates> MineCoordinates(IEnumerable<string> mines)
        {
            return mines.Select(objectCoordinate => ObjectCoordinates(objectCoordinate.Split(',').Select(int.Parse).ToList())).ToList();
        }
        
        /// <summary>
        /// This method will perform three distinct actions required to create the <see cref="TurtleChallenge.Board"/>. This is done by
        /// calling the <see cref="MineCoordinates"/> method to create the mine <see cref="Coordinates"/> and
        /// <see cref="ObjectCoordinates"/> to create the exit <see cref="Coordinates"/>.
        /// </summary>
        /// <param name="lines">A string array containing the game-settings found in the file</param>
        /// <returns>A configured <see cref="TurtleChallenge.Board"/>  object</returns>
        private static Board ConfigureBoard(string[] lines)
        {
            Validator = new Validation();
            //Expected format: 5 4
            var boardSettings = lines.ElementAt(0).Split(' ').Select(int.Parse).ToList();
            Validation.ValidateBoard(boardSettings);
            //Expected format: 1,1 1,3 3,3
            var mines = MineCoordinates(lines.ElementAt(1).Split(' ').ToList());
            //Expected format: 4 2
            var exit = ObjectCoordinates(lines.ElementAt(2).Split(' ').Select(int.Parse).ToList());
            
            var board = new Board();
            board.CreateBoard(boardSettings, mines, exit);
            Validation.IsExitAMine(board, exit);
            return board;
        }

        /// <summary>
        /// This method splits the string into three different components. The components include two
        /// integers which uses the <see cref="ObjectCoordinates"/> to create the <see cref="Coordinates"/> and one
        /// <see cref="Direction"/> needed to create <see cref="TurtleChallenge.Turtle"/>.
        /// </summary>
        /// <param name="settings">A string of turtle settings</param>
        /// <returns>A <see cref="TurtleChallenge.Turtle"/>  object with <see cref="Coordinates"/> and <see cref="Direction"/></returns>
        private static Turtle CreateTurtle(string settings)
        {
            //Expected format: 0 1 N
            var turtleSettings = settings.Split(' ').ToList();
            var turtleCoordinates = ObjectCoordinates(turtleSettings.Take(2).Select(int.Parse).ToList());
            var turtleDirection = (Direction) Enum.Parse(typeof(Direction), turtleSettings[2]);
            
            return new Turtle(turtleCoordinates, turtleDirection);
        }
    }
}