using System;
using System.Collections.Generic;

public class Solution {
    
    public int LongestCommonSubsequence(string text1, string text2) {
        
        int m = text1.Length, n = text2.Length;
        
        int[,] dp = new int[m+1,n+1];
        
        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(text1[i-1] == text2[j-1])      //Note - the difference between indices in dp table and strings
                {
                    dp[i,j] = 1 + dp[i-1,j-1];    //take 1 + diagonal value
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }     
            }
        }
        
        // for(int i=0; i<m; i++)
        // {
        //     for(int j=0; j<n; j++)
        //     {
        //       Console.Write(dp[i,j] + " ");  
        //     }
        //     Console.WriteLine();
        // }
        
        return dp[m,n];
    }
    
    public static void Main(string[] args)
		{
			
			string s1 = "ace";
			string s2 = "abcde";
			
			var obj = new Solution();
			int ans = obj.LongestCommonSubsequence(s1, s2);
			
			Console.WriteLine(ans);
		}
}