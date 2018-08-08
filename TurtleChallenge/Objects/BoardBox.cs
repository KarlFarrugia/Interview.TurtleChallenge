namespace TurtleChallenge.Objects
{
    /// <summary>
    /// A class structure containing the board boxes with the Mine and Exit boolean objects. The way this stuct is
    /// designed is that through the <see cref="Board"/> class each box is instantiated as having the Mine and Exit
    /// boolean as false. After the instantiation the list of Mines is traversed and the relevant boxes have the mine
    /// boolean turned to true. Then exit <see cref="Coordinates"/> are used to turn the Exit boolean to true.
    /// </summary>
    public struct BoardBox
    {
        public bool Mine { get; set; }
        public bool Exit { get; set; }
    }
}