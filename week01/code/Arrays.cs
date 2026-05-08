public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Approach: Create an array of the specified length, then loop from 0 to length-1,
        // calculating each multiple and assigning it to the array.
        // Finally, return the array.
        
        // Create an array of the specified length
        double[] multiples = new double[length];

        // Loop through the array indices
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple and assign it to the array
            multiples[i] = number * (i + 1);
        }

        // Return the array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Approach: Reverse 3 times
        // 1. Reverse the entire list
        // 2. Reverse the first 'amount' elements
        // 3. Reverse the remaining elements
        // Results in a right rotation)

        // Calculate the effective rotation amount (not needed if amount is guaranteed to be in range)
        int n = data.Count;
        
        // Handle cases where amount is greater than n
        amount = amount % n;

        // 1. Reverse the entire list
        data.Reverse();

        // Reverse the first 'amount' elements
        data.Reverse(0, amount);

        // 3. Reverse the remaining 'n - amount' elements
        data.Reverse(amount, n - amount);

        // Results: The list is now rotated to the right by the specified amount
        // Existing list 'data' is modified in place
        // No return needed
    }
}
