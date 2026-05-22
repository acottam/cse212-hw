/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // If 1st element in the array is false, then we can't move left.
        if (!_mazeMap[(_currX, _currY)][0])
            // If we can't move left, then throw an exception.
            throw new InvalidOperationException("Can't go that way!");
        
        // We can move left: decrement the x value.
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // If 2nd element in the array is false, then we can't move right.  
        if (!_mazeMap[(_currX, _currY)][1])
            // If we can't move right, then throw an exception.
            throw new InvalidOperationException("Can't go that way!");
        
        // We can move right: increment the x value.
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // If 3rd element in the array is false, then we can't move up.
        if (!_mazeMap[(_currX, _currY)][2])
            // If we can't move up, then throw an exception.
            throw new InvalidOperationException("Can't go that way!");
        
        // We can move up: decrement the y value.
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // If 4th element in the array is false, then we can't move down.
        if (!_mazeMap[(_currX, _currY)][3])
            // If we can't move down, then throw an exception.
            throw new InvalidOperationException("Can't go that way!");
        
        // We can move down: increment the y value.
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}