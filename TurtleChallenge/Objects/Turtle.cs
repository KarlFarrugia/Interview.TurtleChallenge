using System;
using TurtleChallenge.Objects;

namespace TurtleChallenge
{
    /// <summary>
    /// This class is used to create the turtle object which will perform the sequence of <see cref="Moves"/> on a
    /// <see cref="Board"/>.
    /// </summary>
    public class Turtle
    {
        public int TurtleCoordinateX { get; set; }
        public int TurtleCoordinateY { get; set; }
        public Direction Direction { get; set; }

        /// <summary>
        /// The Turtle Construtctor takes the <see cref="Coordinates"/> and <see cref="TurtleChallenge.Direction"/> to instantiate the
        /// object
        /// </summary>
        /// <param name="coordinates">The starting <see cref="Coordinates"/> of the turtle</param>
        /// <param name="startingDirection">The starting <see cref="TurtleChallenge.Direction"/> of the turtle</param>
        public Turtle(Coordinates coordinates, Direction startingDirection)
        {
            TurtleCoordinateX = coordinates.CoordinateX;
            TurtleCoordinateY = coordinates.CoordinateY;
            Direction = startingDirection;
        }

        /// <summary>
        /// Takes the current turtle <see cref="Direction"/> and rotates it clockwise to the right.
        /// </summary>
        /// <returns>The <see cref="TurtleChallenge.Direction"/> after performing a right rotation</returns>
        /// <exception cref="ArgumentOutOfRangeException">Default Exception if case does not match</exception>
        public Direction RotateRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    return Direction.E;
                case Direction.E:
                    return Direction.S;
                case Direction.S:
                    return Direction.W;
                case Direction.W:
                    return Direction.N;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        /// <summary>
        /// Takes the current turtle <see cref="Direction"/> and rotates it anticlockwise to the left.
        /// </summary>
        /// <returns>The <see cref="TurtleChallenge.Direction"/> after performing a left rotation</returns>
        /// <exception cref="ArgumentOutOfRangeException">Default Exception if case does not match</exception>
        public Direction RotateLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    return Direction.W;
                case Direction.W:
                    return Direction.S;
                case Direction.S:
                    return Direction.E;
                case Direction.E:
                    return Direction.N;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Takes the current turtle <see cref="Coordinates"/> and moves it by one position in the
        /// <see cref="Direction"/> the turtle is facing.
        /// </summary>
        /// <returns>The <see cref="Coordinates"/> after performing a single move</returns>
        /// <exception cref="ArgumentOutOfRangeException">Default Exception if case does not match</exception>
        public Coordinates Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    return new Coordinates{CoordinateX = TurtleCoordinateX, CoordinateY = TurtleCoordinateY - 1};
                case Direction.W:
                    return new Coordinates{CoordinateX = TurtleCoordinateX - 1, CoordinateY = TurtleCoordinateY};
                case Direction.S:
                    return new Coordinates{CoordinateX = TurtleCoordinateX, CoordinateY = TurtleCoordinateY + 1};
                case Direction.E:
                    return new Coordinates{CoordinateX = TurtleCoordinateX + 1, CoordinateY = TurtleCoordinateY};
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// This method returns the current <see cref="Coordinates"/> of the turtle.
        /// </summary>
        /// <returns>The turtle <see cref="Coordinates"/></returns>
        public Coordinates TutleCoordinates()
        {
            return new Coordinates {CoordinateX = TurtleCoordinateX, CoordinateY = TurtleCoordinateY};
        }
    }
}