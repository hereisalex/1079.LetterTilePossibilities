//You have n  tiles, where each tile has one letter tiles[i] printed on it.

//Return the number of possible non-empty sequences of letters you can make using the letters printed on those tiles.

public class Solution {
    public int NumTilePossibilities(string tiles) {
        // Create a dictionary to count the occurrences of each character in the input string
        var count = new Dictionary<char, int>();
        foreach (var tile in tiles)
        {
            if (count.ContainsKey(tile))
                count[tile]++;
            else
                count[tile] = 1;
        }
    
        // Call the recursive method to calculate the number of permutations
        return TilePermutations(count);
    }

    // This recursive method calculates the number of permutations of the tiles
    private int TilePermutations(Dictionary<char, int> count)
    {
        int sum = 0; // Initialize the sum of permutations

        // Iterate through each character in the dictionary
        foreach (var key in count.Keys)
        {
            if (count[key] == 0) // Skip characters that have been used up
                continue;

            sum++; // Count the current character as a valid permutation

            // Decrement the count of the current character and call the method recursively
            count[key]--;
            sum += TilePermutations(count);

            // Restore the count of the current character for the next iteration
            count[key]++;
        }
    return sum; // Return the total number of permutations
    }
}
