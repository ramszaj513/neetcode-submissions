public class Solution {
    public List<int> FindMinHeightTrees(int n, int[][] edges) {
        // only one path between each vertices
        // there is no cycles

        // n vertecies and n-1 edges

        // we need to find a minimum height trees within the provided vertexes and edges
        // min height tree is a tree where the path from root to leaf i shortest

        // how to calcualte the height of a given root?
        // we do dfs and that way we know the largest distance from the root to the leaf
        // the bruteforce solution would be to trough all of the vertices and calculate their heights.

        // we can start from leafes and propagate the distance trhough the whole tree when two propagations meet we update the result value
        // then we iterate and take the min

        // how to iterate trough a tree starting from leafs???
        // I can do it with starting a dfs from each leaf in the tree (but that can be a lot)
        // ofcourse the given propagation ends if the distance is the same as before or smaller

        // I am thinking of a BFS implemented via a queue where on the start I enqueue only the leafs.

        if(n == 1) return new List<int>{0};

        Dictionary<int,List<int>> map = new();
        int[] degree = new int[n];

        for(int i = 0; i < edges.Length; i++){
            if(!map.ContainsKey(edges[i][0])){
                map[edges[i][0]] = new List<int>();
            }
            if(!map.ContainsKey(edges[i][1])){
                map[edges[i][1]] = new List<int>();
            }
            map[edges[i][0]].Add(edges[i][1]);
            degree[edges[i][0]]++;
            map[edges[i][1]].Add(edges[i][0]);
            degree[edges[i][1]]++;
        }

        
        Queue<int> q = new Queue<int>();
        for(int i = 0; i < n; i++){
            if(degree[i] == 1){
                q.Enqueue(i);
            }
        }

        int remainingNodes = n;
        while (remainingNodes > 2) {
            int leafCount = q.Count;
            remainingNodes -= leafCount;

            for (int i = 0; i < leafCount; i++) {
                int leaf = q.Dequeue();
                
                foreach (int neighbor in map[leaf]) {
                    degree[neighbor]--;
                    
                    if (degree[neighbor] == 1) {
                        q.Enqueue(neighbor);
                    }
                }
            }
        }

        return q.ToList();
    }
}