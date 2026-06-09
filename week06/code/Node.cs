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
        
        // Calculate the height of the left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        
        // Calculate the height of the right subtree
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Return the height of the tree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}