public class Solution {
    // UNION-FIND SOLUTION

    private int[] parent;
    private int[] rank;

    // public int Find(int i){
    //     int res = i;

    //     while(res != parent[res]){
    //         parent[res] = parent[parent[res]];
    //         res = parent[res];
    //     }

    //     return res;
    // }

    public int Find(int i) {
        if (parent[i] == i)
            return i;
        
        return parent[i] = Find(parent[i]);
    }

    public int Union(int n1, int n2){
        int p1 = Find(n1);
        int p2 = Find(n2);

        if(p1 == p2) return 0;

        if(rank[p2] > rank[p1]){
            parent[p1] = p2;
            rank[p2] += rank[p1];
        } else{
            parent[p2] = p1;
            rank[p1] += rank[p2];
        }

        return 1;
    }

    public int CountComponents(int n, int[][] edges) {
        parent = new int[n];
        rank = new int[n];
        for(int i = 0; i < n; i++){
            parent[i] = i;
            rank[i] = 0;
        }
        
        int result = n;
        for(int i = 0; i < edges.Length; i++){
            result -= Union(edges[i][0], edges[i][1]);
        }

        return result;
    }


    // DFS SOLUTION
    // public int CountComponents(int n, int[][] edges) {
    //     List<List<int>> neighs = new List<List<int>>();
    //     for(int i = 0; i < n; i++){
    //         neighs.Add(new List<int>());
    //     }

    //     for(int i = 0; i < edges.Length; i++){
    //         neighs[edges[i][1]].Add(edges[i][0]);
    //         neighs[edges[i][0]].Add(edges[i][1]);
    //     }

    //     HashSet<int> visited = new();

    //     int res = 0;
    //     for(int i = 0; i < n; i++){
    //         if(!visited.Contains(i)){
    //             res++;
    //             dfs(i, visited,neighs);
    //         }
    //     }

    //     return res;
    // }

    // private void dfs(int i, HashSet<int> visited, List<List<int>> neighs){
    //     visited.Add(i);
        
    //     foreach(var node in neighs[i]){
    //         if(!visited.Contains(node)){
    //             dfs(node, visited, neighs);
    //         }
    //     }
    // }
}
