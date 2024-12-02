using System;
using System.Collections.Generic;

public class Solution 
{
    public string MinWindow(string s, string t) 
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

        // Frequency map for characters in t
        Dictionary<char, int> required = new Dictionary<char, int>();
        foreach (char c in t) 
        {
            if (!required.ContainsKey(c)) required[c] = 0;
            required[c]++;
        }

        // Sliding window pointers
        int left = 0, right = 0;
        int formed = 0, requiredCount = required.Count;
        int minLength = int.MaxValue, startIndex = 0;

        Dictionary<char, int> windowCounts = new Dictionary<char, int>();

        while (right < s.Length) 
        {
            char c = s[right];
            if (!windowCounts.ContainsKey(c)) windowCounts[c] = 0;
            windowCounts[c]++;

            // If current character's count matches the required count
            if (required.ContainsKey(c) && windowCounts[c] == required[c]) 
            {
                formed++;
            }

            // Try to shrink the window until it becomes invalid
            while (formed == requiredCount) 
            {
                char leftChar = s[left];

                // Update the result
                if (right - left + 1 < minLength) 
                {
                    minLength = right - left + 1;
                    startIndex = left;
                }

                // Shrink the window
                windowCounts[leftChar]--;
                if (required.ContainsKey(leftChar) && windowCounts[leftChar] < required[leftChar]) 
                {
                    formed--;
                }
                left++;
            }

            right++;
        }

        if(minLength != int.MaxValue)
            return s.Substring(startIndex, minLength);

        return "";
    }
}
