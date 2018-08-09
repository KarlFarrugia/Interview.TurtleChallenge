using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TurtleChallenge.Game;
using TurtleChallenge.Objects;
using TurtleChallenge.Objects.BoardComponents;

namespace UnitTests
{
    /// <summary>
    /// A set of Unit Tests with the aim of testing different aspects of the turtle program execution.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Tests that the <see cref="Coordinates"/> structure holds the X and Y coordinates properly.
        /// </summary>
        [TestCase]
        public void TestCoordinates()
        {
            var coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 2};
            Assert.AreEqual(coordinates.CoordinateX, 4);
            Assert.AreEqual(coordinates.CoordinateY, 2);
        }
      
        /// <summary>
        /// Tests the <see cref="Turtle"/> constructor saves the turtle's starting settings correctly.
        /// </summary>
        [TestCase]
        public void TestTurtle()
        {
            var turtle = new Turtle(new Coordinates {CoordinateX = 4, CoordinateY = 2}, Direction.N);
            Assert.AreEqual(turtle.Direction, Direction.N);
            Assert.AreEqual(turtle.Coordinates.CoordinateX, 4);
            Assert.AreEqual(turtle.Coordinates.CoordinateY, 2);
        }
        
        /// <summary>
        /// Tests that an <see cref="Turtle"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullTurtle()
        {
            Assert.Throws<ArgumentNullException>(() => new Turtle()); 
        }
        
        /// <summary>
        /// Tests the <see cref="Moves"/> enumerated type.
        /// </summary>
        [TestCase]
        public void TestMoves()
        {
            Assert.IsInstanceOf(typeof(Moves), Moves.M);
        }

        /// <summary>
        /// Tests the <see cref="Direction"/> enumerated type.
        /// </summary>
        [TestCase]
        public void TestDirection()
        {
            Assert.IsInstanceOf(typeof(Direction), Direction.N);
        }
        
        /// <summary>
        /// Tests that the loaded set of <see cref="Mine"/>s have been created properly.
        /// </summary>
        [TestCase]
        public void TestMine()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            var configurationsReader = new ConfigurationsReader(settings);
            var coordinates = new Coordinates {CoordinateX = 1, CoordinateY = 1};
            Assert.AreEqual(true,configurationsReader.Board.IsMine(coordinates));        
        }

        /// <summary>
        /// Tests that a <see cref="Mine"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullMine()
        {
            Assert.Throws<ArgumentNullException>(() => new Mine()); 
        }
        
        /// <summary>
        /// Tests that a box that is supposed to be a non-<see cref="Mine"/> is in fact not a mine.
        /// </summary>
        [TestCase]
        public void TestNotMine()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            var configurationsReader = new ConfigurationsReader(settings);
            var coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 1};
            Assert.AreEqual(false,configurationsReader.Board.IsMine(coordinates));        
        }
        
        /// <summary>
        /// Tests that the <see cref="Exit"/> Box has been created properly.
        /// </summary>
        [TestCase]
        public void TestExit()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            var configurationsReader = new ConfigurationsReader(settings);
            var coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 2};
            Assert.AreEqual(true,configurationsReader.Board.IsExit(coordinates));
        }
        
        /// <summary>
        /// Tests that an <see cref="Exit"/> cannot be null.
        /// </summary>
        [TestCase]
        public void TestNullExit()
        {
            Assert.Throws<ArgumentNullException>(() => new Exit()); 
        }
        
        /// <summary>
        /// Tests that a box that is supposed to be a non-<see cref="Exit"/> is in fact not an exit.
        /// </summary>
        [TestCase]
        public void TestNotExit()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            var configurationsReader = new ConfigurationsReader(settings);
            var coordinates = new Coordinates {CoordinateX = 0, CoordinateY = 2};
            Assert.AreEqual(false,configurationsReader.Board.IsExit(coordinates));
        }
        
        /// <summary>
        /// This test asserts that an <see cref="Exit"/> cannot be a <see cref="Mine"/>.
        /// </summary>
        [TestCase]
        public void TestExitIsMine()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "1 1";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            Assert.Throws<Exception>(() => new ConfigurationsReader(settings));
        }
                
        /// <summary>
        /// Tests that receiving correct game-settings does not result in an exception
        /// </summary>
        [TestCase]
        public void TestBoardSettingsCorrect()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            new ConfigurationsReader(settings);
            Assert.Pass();
        }  
        
        /// <summary>
        /// Tests that receiving incorrect game-settings does result in an exception
        /// </summary>
        [TestCase]
        public void TestBoardSettingsIncorrect()
        {
            var settings = new string[6];
            settings[0] = "-1 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            Assert.Throws<Exception>(() => new ConfigurationsReader(settings));
        }  

        /// <summary>
        /// Tests that a <see cref="IBoardComponentInterface"/> cannot lie outside the <see cref="Board"/> area.
        /// </summary>
        [TestCase]
        public void TestOutOfBoard()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "6,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            Assert.Throws<IndexOutOfRangeException>(() => new ConfigurationsReader(settings));
        }
        
        /// <summary>
        /// Tests for incorrect <see cref="Turtle.Direction"/>
        /// </summary>
        [TestCase]
        public void TestIncorrectTurtle()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "1 2";
            settings[3] = "0 1 f";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            Assert.Throws<ArgumentException>(() => new ConfigurationsReader(settings));
        }
        
        /// <summary>
        /// Tests that empty coordinates trigger an exception.
        /// </summary>
        [TestCase]
        public void TestIncorrectSettings()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = " , 1,3 3,3";
            settings[2] = "1 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            settings[5] = "R M M M";
            Assert.Throws<FormatException>(() => new ConfigurationsReader(settings));
        }
        
        /// <summary>
        /// Tests that a run that is supposed to end with a "Mine hit!" outcome does return as expected.
        /// </summary>
        [TestCase]
        public void TestMineHitRun()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "R M L M M";
            var testProgram = new ConfigurationsReader(settings);
            IEnumerable<Moves> moves = testProgram.Games.
                ElementAt(0).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
            Assert.AreEqual("Mine hit!", ExecuteGame.Execute(testProgram.Board, testProgram.Turtle, moves));
        }
           
        /// <summary>
        /// Tests that a run that is supposed to end with a "Success!" outcome does return as expected.
        /// </summary>     
        [TestCase]
        public void TestSuccessRun()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "L L M L M M M M";
            var testProgram = new ConfigurationsReader(settings);
            IEnumerable<Moves> moves = testProgram.Games.
                ElementAt(0).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
            Assert.AreEqual("Success!", ExecuteGame.Execute(testProgram.Board, testProgram.Turtle, moves));
        }
        
        /// <summary>
        /// Tests that a run that is supposed to end with a "Still in danger!" outcome does return as expected.
        /// </summary>    
        [TestCase]
        public void TestStillInDangerRun()
        {
            var settings = new string[6];
            settings[0] = "5 4";
            settings[1] = "1,1 1,3 3,3";
            settings[2] = "4 2";
            settings[3] = "0 1 N";
            settings[4] = "M R M M M";
            var testProgram = new ConfigurationsReader(settings);
            IEnumerable<Moves> moves = testProgram.Games.
                ElementAt(0).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
            Assert.AreEqual("Still in danger!", ExecuteGame.Execute(testProgram.Board, testProgram.Turtle, moves));
        }
    }
}