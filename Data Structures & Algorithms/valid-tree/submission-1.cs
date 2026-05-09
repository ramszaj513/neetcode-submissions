public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // valid tree:
        // - each node is connected
        // - there are no cycles in the graph

        // traverse the graph using a dfs, save the current path, if something repeats on it return false
        // count the number of vertexes (if we traversed the whole graph and the number is smaller then return)
        // the problem with this approach is that we dont know what is the root of the tree, but the edges are undirected so that solves the problem

        List<int>[] neighs = new List<int>[n];
        for(int i = 0; i < edges.Length; i++){
            if(neighs[edges[i][0]] == null) neighs[edges[i][0]] = new List<int>();
            if(neighs[edges[i][1]] == null) neighs[edges[i][1]] = new List<int>();
            neighs[edges[i][0]].Add(edges[i][1]);
            neighs[edges[i][1]].Add(edges[i][0]);
        }

        HashSet<int> path = new();

        bool result = dfs(0, -1, path, neighs);
        return (path.Count == n && result);
    }

    private bool dfs(int i, int last, HashSet<int> path, List<int>[] neighs){
        if(path.Contains(i)) return false;
        path.Add(i);
        if(neighs[i] == null) return true;
        foreach(var node in neighs[i]){
            if(node == last) continue;
            if(!dfs(node, i, path, neighs)) return false;
        }
        return true;    
    }
}
