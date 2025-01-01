public class Solution {
    public int Change(int amount, int[] coins) 
    {
        int n = coins.Length;

        // dp[i][j] represents the number of ways to make amount j using the first i coins
        int[,] dp = new int[n + 1, amount + 1];

        // Base case: There is one way to make amount 0 (by taking no coins)
        for(int i = 0; i <= n; i++) 
        {
            dp[i, 0] = 1;
        }

        for(int i = 1; i <= n; i++) 
        {
            for(int j = 0; j <= amount; j++) 
            {
                // Option 1: Do not take the current coin
                dp[i, j] = dp[i - 1, j];

                // Option 2: Take the current coin (if possible)
                if(j >= coins[i - 1]) 
                {
                    dp[i, j] += dp[i, j - coins[i - 1]];
                }
            }
        }

        // The answer is in dp[n][amount], which represents the number of ways to make the given amount using all coins
        return dp[n, amount];
    }
}
