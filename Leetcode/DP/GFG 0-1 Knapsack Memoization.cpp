#include <bits/stdc++.h>
using namespace std;

class Solution {
  public:
  
    int fooRec(int capacity, int index, vector<int> &val, vector<int> &wt, vector<vector<int>> &dp)
    {
        if(index<0 || capacity==0)  //0 based indexing
            return 0;
        
        // If the result is already computed, return it
        if (dp[index][capacity] != -1) 
        {
            return dp[index][capacity];
        }
        
        if(wt[index] <= capacity)   //take
        {
            int take = val[index] + fooRec(capacity-wt[index], index-1, val, wt, dp);
            int notTake = fooRec(capacity, index-1, val, wt, dp);
            
            dp[index][capacity] = max(take, notTake);
        }
        else        //not take
        {
            int notTake = fooRec(capacity, index-1, val, wt, dp);
            dp[index][capacity] = notTake;
        }
        
        return dp[index][capacity];    
    }
    
    // Function to return max value that can be put in knapsack of capacity.
    int knapSack(int capacity, vector<int> &val, vector<int> &wt) 
    {
        // code here
        int n = val.size();
        int index = n-1;
        
        vector<vector<int>> dp(n, vector<int>(capacity + 1, -1));
        
        return fooRec(capacity, index, val, wt, dp);
    }
};
