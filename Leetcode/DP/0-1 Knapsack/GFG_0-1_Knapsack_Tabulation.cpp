#include <iostream>
#include <bits/stdc++.h>
using namespace std;


int knapsack(int capacity, const vector<int>& weights, const vector<int>& values, int n) 
{
    
    vector<vector<int>> dp(n, vector<int>(capacity + 1, 0));

    // base case - fill the 1st row
    for (int w = weights[0]; w <= capacity; w++) 
    {
        dp[0][w] = values[0]; // taking the 1st item if its weight <= capacity
    }


    for (int i = 1; i < n; i++) 
    {
        for (int w = 0; w <= capacity; w++) 
        { 
            if (weights[i] <= w) 
            {
                int take = values[i] + dp[i - 1][w - weights[i]]; 
                //dp[i - 1][w - weights[i]] is the best value you can get using earlier items and with remaining capacity
                int notTake = 0 + dp[i - 1][w];

                dp[i][w] = max(take, notTake);
            } 
            else 
            {
                dp[i][w] = dp[i - 1][w];    //not take so same as (i-1) selection
            }

            // cout<<dp[i][w]<<" "; 
        }
        // cout<<endl;
    }

    return dp[n - 1][capacity];
}

int main() 
{
    int n = 3;
    int capacity = 5;
    vector<int> values = {6, 10, 12};
    vector<int> weights = {1, 2, 3};

    int maxProfit = knapsack(capacity, weights, values, n);
    cout << "Maximum profit: " << maxProfit << endl;    //ans = 22

    return 0;
}
