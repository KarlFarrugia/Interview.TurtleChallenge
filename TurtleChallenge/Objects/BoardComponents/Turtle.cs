using System;

namespace TurtleChallenge.Objects.BoardComponents
{
    /// <inheritdoc />
    /// <summary>
    /// This class is used to create the turtle object which will perform the sequence of
    /// <see cref="TurtleChallenge.Objects.Moves" /> on a <see cref="TurtleChallenge.Objects.Board" />.
    /// </summary>
    public class Turtle : IBoardComponentInterface
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }
        
        /// <summary>
        /// Turtle cannot be null
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public Turtle()
        {
            throw new ArgumentNullException();
        }
        
        /// <summary>
        /// The Turtle construtctor takes the <see cref="Coordinates"/> and <see cref="Objects.Direction"/> to
        /// instantiate the object
        /// </summary>
        /// <param name="coordinates">The starting <see cref="Coordinates"/> of the turtle</param>
        /// <param name="startingDirection">The starting <see cref="Objects.Direction"/> of the turtle</param>
        public Turtle(Coordinates coordinates, Direction startingDirection)
        {
            Coordinates = coordinates;
            Direction = startingDirection;
        }

        /// <summary>
        /// Takes the current turtle <see cref="Direction"/> and rotates it clockwise.
        /// </summary>
        /// <returns>The <see cref="Objects.Direction"/> after performing a right rotation</returns>
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
        /// Takes the current turtle <see cref="Direction"/> and rotates it anticlockwise.
        /// </summary>
        /// <returns>The <see cref="Objects.Direction"/> after performing a left rotation</returns>
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
                    return new Coordinates{CoordinateX = Coordinates.CoordinateX, CoordinateY = Coordinates.CoordinateY - 1};
                case Direction.W:
                    return new Coordinates{CoordinateX = Coordinates.CoordinateX - 1, CoordinateY = Coordinates.CoordinateY};
                case Direction.S:
                    return new Coordinates{CoordinateX = Coordinates.CoordinateX, CoordinateY = Coordinates.CoordinateY + 1};
                case Direction.E:
                    return new Coordinates{CoordinateX = Coordinates.CoordinateX + 1, CoordinateY = Coordinates.CoordinateY};
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}