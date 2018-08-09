﻿using System;

namespace TurtleChallenge.Objects.BoardComponents
{
    /// <inheritdoc />
    public class Exit : IBoardComponentInterface
    {
        /// <summary>
        /// The correct exit takes <see cref="Coordinates"/> as its parameters.
        /// </summary>
        /// <exception cref="ArgumentNullException">Cannot create a null <see cref="Exit"/></exception>
        public Exit()
        {
            throw new ArgumentNullException();
        }
        
        public Exit(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        
        /// <summary>
        /// The Coordinates for the Exit Component
        /// </summary>
        public Coordinates Coordinates { get; set; }
    }
}