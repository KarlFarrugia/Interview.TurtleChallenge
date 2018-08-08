using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge.Objects;

namespace TurtleChallenge
 {
     /// <summary>
     /// This class loads the file from the command line arguments, configures the game objects and finally executes the
     /// series of moves.
     /// </summary>
     public static class Program 
     {
         /// <summary>
         /// The main method starts off the turtle program by receiving a command line argument, which denotes the path
         /// to the game-settings file.
         ///
         /// Upon loading the file through the <see cref="ConfigurationsReader"/> class the program will start
         /// iterating through every sequence of moves and calling the <see cref="ExecuteGame"/> class which will output
         /// the result to console.
         /// </summary>
         /// <param name="args">As per requirement args is expecting a path to a file</param>
         public static void Main(string[] args)
         {
             ConfigurationsReader turtleProgram = new ConfigurationsReader(args[0]);
             for (var i = 0; i < turtleProgram.Games.Count(); i++)
             {
                 IEnumerable<Moves> moves = turtleProgram.Games.
                     ElementAt(i).Split(' ').Select(s => Enum.Parse(typeof(Moves), s)).Cast<Moves>().ToList();
                 Console.WriteLine("Sequence " + (i + 1) + ": " + ExecuteGame.Execute(turtleProgram.Board, turtleProgram.Turtle, moves));
             }
         }
     }
 }