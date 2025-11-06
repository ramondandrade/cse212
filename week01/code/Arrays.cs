public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    /// 
    
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create a new array of type double with the specified length
        double[] result = new double[length];

        // Initialize a loop counter to go from 0 to length-1
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple by multiplying the number by (position + 1)
            result[i] = number * (i + 1);
        }

        // Return the array
        return result;

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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Handle edge cases and normalize the amount
        if (data.Count == 0 || amount == 0) return;
        amount = amount % data.Count; // Handle cases where amount > data.Count
        if (amount == 0) return; // No rotation needed

        // Get the last 'amount' elements that will move to the front
        List<int> lastPortion = data.GetRange(data.Count - amount, amount);

        // Get the remaining elements from the beginning that will move to the end
        List<int> firstPortion = data.GetRange(0, data.Count - amount);

        // Clear the original list to rebuild it
        data.Clear();

        // Add the last portion first (these will now be at the beginning)
        data.AddRange(lastPortion);

        // Add the first portion at the end
        data.AddRange(firstPortion);
        
    }

}