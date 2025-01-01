using System;
using System.Collections.Generic;


public class Solution 
{
    public static int CoinChange(int[] coins, int amount) 
    {
        int n = coins.Length;

        // Create a DP array to store the minimum coins needed for each amount
        int[] dp = new int[amount + 1];

        // Set all values to a large number (indicating impossible initially)
        for(int i = 1; i <= amount; i++) 
        {
            dp[i] = amount + 1; // Use amount + 1 as a placeholder for "infinity"
        }
        dp[0] = 0;  // Base case: 0 coins are needed to make amount 0


        foreach(int coin in coins) 
        {
            for(int j = coin; j <= amount; j++) 
            {
                dp[j] = Math.Min(dp[j - coin] + 1, dp[j]);  //min of take, notTake
            }
        }

        // If the value for the target amount is still the placeholder, return -1
        return dp[amount] == (amount+1) ? -1 : dp[amount];
    }

    
    public static void Main(string[] args)
    {   
        int amount = 11;
        int[] coins = new int[] {4, 2, 5};
        
        Console.WriteLine(CoinChange(coins, amount));
    }
}
