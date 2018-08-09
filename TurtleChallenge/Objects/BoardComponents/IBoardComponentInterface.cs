namespace TurtleChallenge.Objects.BoardComponents
{
    /// <summary>
    /// An interface for the objects on the board namely <see cref="Mine"/>m<see cref="Exit"/> and <see cref="Turtle"/>
    /// which require them to have at least <see cref="Coordinates"/>
    /// </summary>
    public interface IBoardComponentInterface
    {
        Coordinates Coordinates { get; set; }
    }
}