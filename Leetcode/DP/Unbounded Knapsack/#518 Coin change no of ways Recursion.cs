public class Solution {

    public int Rec(int[] coins, int amount, int index)
    {
        if(amount==0)
            return 1;       //one way - take no coins
        if(index <0 || amount <0)
            return 0;       //no way
        
        if(coins[index] <= amount)
        {
            int take = Rec(coins, amount-coins[index], index);
            int notTake = Rec(coins, amount, index-1);

            return take+notTake;
        }
        else
            return Rec(coins, amount, index-1);     //same as not take
        
    }

    public int Change(int amount, int[] coins) {
        
        int n = coins.Length;

        return Rec(coins, amount, n-1);
    }
}