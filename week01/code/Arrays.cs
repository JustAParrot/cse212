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
        // Create an array of doubles with the specified length
        // Loop from 1 to length
        // For each position i, calculate number * i
        // Assign value to the index of the array
        // Return the array (after loop, ofc)

        // 1: Create the array
        double[] multiples = new double[length];

        // 2: Loop through from 1 to length
        for (int i = 1; i <= length; i++)
        {
            // 3 & 4: Calculate the i multiple and store it
            multiples[i - 1] = number * i;
        }

        // 5: Return the array
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
        // Find the index where the rotation split should happen. Split the list at index 
        // Use GetRange to extract the last 'amount' elements into a new list 
        // Use GetRange to extract the first elements into another list 
        // Clear the original list (careful with this one)
        // Add the rotated two parts back in order: first the right part and then the left

        // 1: Calculate the split point
        int splitIndex = data.Count - amount;

        // 2: Get the last 'amount' elements
        var rightPart = data.GetRange(splitIndex, amount);

        // 3: Get the first part of the list
        var leftPart = data.GetRange(0, splitIndex);

        // 4: Clear the original list
        data.Clear();

        // 5: Add the rotated parts back in the correct order
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
