namespace TurtleChallenge.Objects.BoardComponents
{
    /// <summary>
    /// An interface for the objects on the board namely <see cref="Mine"/>m<see cref="Exit"/> and <see cref="Turtle"/>
    /// which require them to have at least <see cref="Coordinates"/>.
    /// </summary>
    public interface IBoardComponentInterface
    {
        /// <summary>
        /// Till now the Coordinates of an interface are not used. However, each object that extends this interface must
        /// implement their own <see cref="Coordinates"/>. The reason for this logic is because it is not attractive to
        /// have the <see cref="Exit"/> and <see cref="Mine"/> being indistinguishable.
        /// </summary>
        Coordinates Coordinates { get; set; }
    }
}