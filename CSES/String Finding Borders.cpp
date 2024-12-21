#include <iostream>
#include <bits/stdc++.h>
using namespace std;

int main() 
{
    string s;
    cin>>s;
    
    int n = s.length();
    
    int maxBorderLen = n-1;
    
    for(int i=1; i<=maxBorderLen; i++)
    {
      string left = s.substr(0, i);
      
      string right = s.substr(n-i, i);
      
      if(left == right)
        cout<< i<< " ";
    }
    
    return 0;
}
