public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<List<int>> neighs = new List<List<int>>();
        for(int i = 0; i < n; i++){
            neighs.Add(new List<int>());
        }

        for(int i = 0; i < edges.Length; i++){
            neighs[edges[i][1]].Add(edges[i][0]);
            neighs[edges[i][0]].Add(edges[i][1]);
        }

        HashSet<int> visited = new();

        int res = 0;
        for(int i = 0; i < n; i++){
            if(!visited.Contains(i)){
                res++;
                dfs(i,-1,visited,neighs);
            }
        }

        return res;
    }

    private void dfs(int i, int parent, HashSet<int> visited, List<List<int>> neighs){
        visited.Add(i);
        
        foreach(var node in neighs[i]){
            if(!visited.Contains(node)){
                dfs(node, i, visited, neighs);
            }
        }
    }
}
