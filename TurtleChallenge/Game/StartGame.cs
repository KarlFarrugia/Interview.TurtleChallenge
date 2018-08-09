using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects;

namespace TurtleChallenge.Game
{
    public static class StartGame
    {
        /// <summary>
        /// Upon loading the file through the <see cref="ConfigurationsReader"/> class the program will start
        /// iterating through every sequence of moves and calling the <see cref="ExecuteGame"/> class which will output
        /// the result to console.
        /// </summary>
        /// <param name="file">As per requirement args is expecting a path to a file</param>
        public static void Game(string file)
        {
            var turtleProgram = new ConfigurationsReader(file);
            for (var i = 0; i < turtleProgram.Games.Count(); i++)
            {
                IEnumerable<Moves> moves = turtleProgram.Games.
                    ElementAt(i).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
                Console.WriteLine("Sequence " + (i + 1) + ": " + ExecuteGame.Execute(turtleProgram.Board, turtleProgram.Turtle, moves));
            }
        }
    }
}