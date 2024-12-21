#include <iostream>
#include <bits/stdc++.h>
using namespace std;

const int MAXN = 2e5 + 5;
int ans[MAXN];

void dfs(vector<int> adj[], int bossId)
{
  for(auto empdId : adj[bossId])
  {
    dfs(adj, empdId);
    ans[bossId] = ans[bossId] + (ans[empdId]+1);
  }
  
}

int main() 
{
  int N; cin>>N;
  
  int boss[N-1];
  
  for(int i=0; i<N-1; i++)
    cin>>boss[i];
  
  vector<int> adj[N+1];
  
  for(int i=0; i<N-1; i++)
    adj[boss[i]].push_back(i+2);
    
  // for(int i=1; i<N+1; i++)
  // {
  //   vector<int> temp = adj[i];
  //   int n = temp.size();
    
  //   for(int j=0; j<n; j++)
  //     cout<<temp[j]<<" ";
    
  //   cout<<endl;
  // }
  
  dfs(adj, 1);
  
  for(int i=1; i<=N; i++)
    cout<<ans[i]<<" ";
  
  return 0;
}