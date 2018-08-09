using TurtleChallenge.Objects;

namespace TurtleChallenge.Game
{
    /// <summary>
    /// This class loads the game configurations and then executes the turtle game
    /// </summary>
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
            var gameConfiguration = new ConfigurationsReader(file);
            var turtleGame = new ExecuteGame(gameConfiguration.Games);
            turtleGame.ExecuteGames(gameConfiguration.Board, gameConfiguration.Turtle, gameConfiguration.Games);
        }
    }
}