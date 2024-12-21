#include <iostream>
#include <bits/stdc++.h>
using namespace std;

int main() 
{
    string master, pattern;
    cin>>master>>pattern;
    
    int m = master.length(), n = pattern.length();
    int i = 0, j = 0;
    
    int count = 0;
    
    while(i < m)
    {
      if(j==n)
      {
        count++; j=0;
      }
      if(master[i]==pattern[j])
      {
        i++; j++;
      }
      else
      {
        i++; j=0;
      }
    }
    if(j==n)
    {
      count++;
    }
    cout<<count;
    
    return 0;
}