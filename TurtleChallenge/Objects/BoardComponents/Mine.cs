using System;

namespace TurtleChallenge.Objects.BoardComponents
{
    /// <inheritdoc />
    /// <summary>
    /// The Mine object on the board is represented using this class
    /// </summary>
    public class Mine : IBoardComponentInterface
    {
        /// <summary>
        /// The correct mine takes <see cref="Coordinates"/> as its parameters.
        /// </summary>
        /// <exception cref="ArgumentNullException">Cannot create a null <see cref="Mine"/></exception>
        public Mine()
        {
            throw new ArgumentNullException();
        }
        
        public Mine(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        
        /// <summary>
        /// The Coordinates for each Mine Component
        /// </summary>
        public Coordinates Coordinates { get; set; }
    }
}