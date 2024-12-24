#include <iostream>
#include <vector>
#include <stack>

using namespace std;

const int MAXN = 2e5 + 5;
vector<int> adj[MAXN];  // Adjacency list for the tree
int subordinates[MAXN];  // Array to store the number of subordinates for each node

void calculateSubordinates(int n) {
    stack<int> stk;  // Stack to simulate DFS
    vector<int> state(n + 1, 0);  // State to track whether the node is being visited for the first time or after visiting children
    stk.push(1);  // Start DFS from the root node (node 1)
    
    while (!stk.empty()) {
        int node = stk.top();

        // If the node is being visited for the first time (state == 0)
        if (state[node] == 0) {
            state[node] = 1;  // Mark the node as visited
            
            // Push all children of the current node to the stack
            for (int child : adj[node]) {
                stk.push(child);
            }
        } else {
            // If we are visiting the node after its children
            stk.pop();
            
            // Calculate the subordinates of the current node
            for (int child : adj[node]) {
                subordinates[node] += subordinates[child] + 1;  // Add subordinates of the child + the child itself
            }
        }
    }
}

int main() {
    int n;
    cin >> n;

    // Read the parent-child relationships and build the tree
    for (int i = 2; i <= n; i++) {
        int parent;
        cin >> parent;
        adj[parent].push_back(i);  // Connect child i to its parent
    }

    // Calculate subordinates for each node
    calculateSubordinates(n);

    // Output the result
    for (int i = 1; i <= n; i++) {
        cout << subordinates[i] << " ";
    }
    cout << endl;

    return 0;
}

