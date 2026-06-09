public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        // If value is equal to Data, do nothing (no duplicates allowed)
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            // Recursive call to insert the value in the right subtree
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If value is equal to Data, return true
        if (value == Data)
            // Value is equal to Data
            return true;
        
        // Search left subtree
        if (value < Data)
            // Search the left subtree
            return Left != null && Left.Contains(value);
        
        // Search the right subtree
        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}