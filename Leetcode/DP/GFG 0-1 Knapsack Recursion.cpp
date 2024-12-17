#include <bits/stdc++.h>
using namespace std;

class Solution {
  public:
  
    int fooRec(int capacity, int index, vector<int> &val, vector<int> &wt)
    {
        if(index==0 || capacity==0)
            return 0;
        
        if(wt[index] <= capacity)   //take
        {
            int take = val[index] + fooRec(capacity-wt[index], index-1, val, wt);
            int notTake = fooRec(capacity, index-1, val, wt);
            
            return max(take, notTake);
        }
        else        //not take
        {
            int notTake = fooRec(capacity, index-1, val, wt);
            return notTake;
        }
            
    }
    
    // Function to return max value that can be put in knapsack of capacity.
    int knapSack(int capacity, vector<int> &val, vector<int> &wt) {
        // code here
        
        int index = val.size()-1;
        
        return fooRec(capacity, index, val, wt);
    }
};