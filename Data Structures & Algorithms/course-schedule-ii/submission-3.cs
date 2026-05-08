public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // go trough each path
        // if there is a cycle return false
        // in each vertex add it to the result we are doing dfs and each of the nodes is visited only ones so we can do it for each node directly
        // we have to check if the node exist in the path before we see if it is visited

        if(numCourses == 0 || prerequisites.Length == 0){
            int[] resultArr = new int[numCourses];
            for(int i = 0; i < numCourses; i++){
                resultArr[i] = i;
            }
            return resultArr;
        } 

        var next = new List<int>[numCourses];
        for(int i = 0; i < numCourses; i++) next[i] = new List<int>(); 
        for(int i = 0 ; i < prerequisites.Length; i++){
            next[prerequisites[i][1]].Add(prerequisites[i][0]);
        }

        int[] visited = new int[numCourses];
        for(var i = 0; i < numCourses; i++)
        {
            visited[i] = 0;
        }

        List<int> res = new();
        for(int i = 0; i < numCourses; i++){
            if(visited[i] != 2){
                if(dfs(i,next,visited,res) == false){
                    return [];
                };
            }
        }

        res.Reverse();
        return res.ToArray();
    }

    private bool dfs(int curr, List<int>[] next, int[] visited, List<int> res) {
        if (visited[curr] == 1) return false;
        if (visited[curr] == 2) return true;

        visited[curr] = 1;
        
        foreach (var neigh in next[curr]) {
            if (!dfs(neigh, next, visited, res)) return false;
        }

        visited[curr] = 2;
        res.Add(curr);
        return true;
    }
}
