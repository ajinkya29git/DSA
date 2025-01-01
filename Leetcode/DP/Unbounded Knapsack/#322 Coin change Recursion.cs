using System;
using System.Collections.Generic;


public class Solution 
{
    public static int Rec(int[] coins, int amount, int index) 
    {

        if (amount == 0) 
            return 0; // No coins needed if the amount is 0
        if (index < 0 || amount < 0) 
            return -1; // No valid combination if index reaches 0 or amount becomes negative

        // Option 1: Take the current coin
        int take = Rec(coins, amount - coins[index], index);
        if (take != -1) 
            take += 1; // Only increment when valid and not always

        // Option 2: Skip the current coin
        int notTake = Rec(coins, amount, index - 1);

        // Combine the results
        if (take == -1) 
            return notTake;     // If "take" is invalid, return "notTake"
        
        if (notTake == -1) 
            return take;        // If "notTake" is invalid, return "take"
        
        return Math.Min(take, notTake); // Otherwise, if both valid return the minimum of valids
    }

    public static int CoinChange(int[] coins, int amount) 
    {
        int n = coins.Length;
        int result = Rec(coins, amount, n-1);
        return result == -1 ? -1 : result;  // If no solution, return -1
    }
    
    public static void Main(string[] args)
    {
        int amount = 11;
        int[] coins = new int[] {4, 2, 5};
        
        Console.WriteLine(CoinChange(coins, amount));
    }
}
