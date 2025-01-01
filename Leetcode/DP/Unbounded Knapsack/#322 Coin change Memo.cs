public class Solution {
    
    public static int Rec(int[] coins, int amount, int index, int[,] memo)
    {
        if(amount == 0)
            return 0;           //no coin needed
        if(index <0 || amount < 0) 
            return -1;          //invalid

        if (memo[index, amount] != -2) 
            return memo[index, amount];
        
        int take = Rec(coins, amount-coins[index], index, memo);
        if(take!=-1)
            take +=1;          //only increment if valid

        int notTake = Rec(coins, amount, index-1, memo);

        int result;
        if(take==-1)
            result = notTake;
        else if(notTake==-1)
            result = take;
        else
            result = Math.Min(take, notTake);

        memo[index, amount] = result;
        return result;
    }
    
    public static int CoinChange(int[] coins, int amount) 
    {
        
        int n = coins.Length;
        int[,] memo = new int[n,amount+1];

        for(int i=0; i<n; i++) 
        {
            for(int j=0; j<=amount; j++) 
            {
                memo[i, j] = -2;
            }
        }
        
        return Rec(coins, amount, n-1, memo);
    }

    public static void Main(string[] args)
    {
        int amount = 11;
        int[] coins = new int[] {4, 2, 5};
        
        Console.WriteLine(CoinChange(coins, amount));
    }
}