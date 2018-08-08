using System;
using NUnit.Framework;
using TurtleChallenge;
using TurtleChallenge.Objects;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void TestCoordinates()
        {
            var coordinates = new Coordinates {CoordinateX = 4, CoordinateY = 2};
            Assert.AreEqual(coordinates.CoordinateX, 4);
            Assert.AreEqual(coordinates.CoordinateY, 2);
        }
      
        [TestCase]
        public void TestTurtle()
        {
            var turtle = new Turtle(new Coordinates {CoordinateX = 4, CoordinateY = 2}, Direction.N);
            Assert.AreEqual(turtle.Direction, Direction.N);
            Assert.AreEqual(turtle.TurtleCoordinateX, 4);
            Assert.AreEqual(turtle.TurtleCoordinateY, 2);
        }
        
        [TestCase]
        public void TestMoves()
        {
            Assert.IsInstanceOf(typeof(Moves), Moves.M);
        }

        [TestCase]
        public void TestDirection()
        {
            Assert.IsInstanceOf(typeof(Direction), Direction.N);
        }
        
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
    }
}