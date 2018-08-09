namespace TurtleChallenge.Objects
{
    /// <summary>
    /// A class structure containing the board boxes with the Mine and Exit boolean objects. The way this stuct is
    /// designed is that through the <see cref="Board"/> class each box is instantiated as having the Mine and Exit
    /// boolean as default. After the instantiation the list of Mine <see cref="Coordinates"/> is traversed and the
    /// relevant boxes have the mine boolean set to true. Then exit <see cref="Coordinates"/> are used to set the Exit
    /// boolean to true. 
    /// </summary>
    public struct BoardBox
    {
        public bool Mine { get; set; }
        public bool Exit { get; set; }
    }
}