using TurtleChallenge.Game;

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
         /// to the game-settings file, and calls the <see cref="StartGame"/> class to start the game
         /// </summary>
         /// <param name="args">As per requirement args is expecting a path to a file</param>
         public static void Main(string[] args)
         {
             StartGame.Game(args[0]);
         }
     }
 }