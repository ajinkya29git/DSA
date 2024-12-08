#include <iostream>
#include <bits/stdc++.h>

using namespace std;

struct Node
{
    int data;
    struct Node* left;
    struct Node* right;

    Node(int x)
    {
        data = x;
        left = right = NULL;
    }
};


class Solution 
{
  public:
    
    void dfs(Node* node, vector<vector<int>>& ans, vector<int>& path)
    {
        if(node==NULL)
            return;
        
        path.push_back(node->data);
        
        if(node->left == NULL && node->right == NULL)
        {
            ans.push_back(path);
        }
        
        dfs(node->left, ans, path);
        
        dfs(node->right, ans, path);
        
        //IMP - Backtracking step
        path.pop_back();
    }
    
    vector<vector<int>> Paths(Node* root) 
    {
        
        vector<vector<int>> ans;
        vector<int> path;
        
        dfs(root, ans, path);
        
        return ans;
        
    }
};