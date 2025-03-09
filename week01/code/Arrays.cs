public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples
        double[] multiples = new double[length];

        // Step 2: Use a loop to populate the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array containing the multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} 
    /// and amount is 3, the result should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the actual shift using modulo, in case amount > data.Count
        int shift = amount % data.Count;

        // Step 2: Extract the last 'shift' elements (the part to move to the front)
        List<int> tail = data.GetRange(data.Count - shift, shift);

        // Step 3: Remove the last 'shift' elements from the original list
        data.RemoveRange(data.Count - shift, shift);

        // Step 4: Insert the extracted elements at the beginning of the list
        data.InsertRange(0, tail);
    }
}
