public class Solution {

    public int Rec(int[] coins, int amount, int index, int[,] memo)
    {
        if(amount==0)
            return 1;       //one way - take no coins
        if(index <0 || amount <0)
            return 0;       //no way
        
        if(memo[index, amount]!=-1)
            return memo[index, amount];
        
        if(coins[index] <= amount)
        {
            int take = Rec(coins, amount-coins[index], index, memo);
            int notTake = Rec(coins, amount, index-1, memo);

            memo[index, amount] = take+notTake;
        }
        else
            memo[index, amount] = Rec(coins, amount, index-1, memo);     //same as not take
        
        return memo[index, amount];
    }

    public int Change(int amount, int[] coins) {
        
        int n = coins.Length;
        int[,] memo = new int[n,amount+1];
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<=amount; j++)
                memo[i, j] = -1;
        }

        return Rec(coins, amount, n-1, memo);
    }
}