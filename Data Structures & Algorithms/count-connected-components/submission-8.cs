public class Solution {
    public int CountComponents(int n, int[][] edges) {
        bool[] visited = new bool[n];
        List<int>[] neighs = new List<int>[n];
        for(int i = 0; i < n; i++){
            neighs[i] = new List<int>();
            visited[i] = false;
        }
        foreach(var edge in edges){
            neighs[edge[0]].Add(edge[1]);
            neighs[edge[1]].Add(edge[0]);
        }

        int res = 0;

        for(int i = 0; i < n; i++){
            if(visited[i] == true) continue;
            dfs(i); 
            res++;
        }

        void dfs(int start){
            Stack<int> stack = new();
            stack.Push(start);
            visited[start] = true;

            while(stack.Count > 0){
                var node = stack.Pop();

                foreach(var next in neighs[node]){
                    if(!visited[next]){
                        stack.Push(next);
                        visited[next] = true;
                    }
                }
            }
        }

        return res;
    }
}
