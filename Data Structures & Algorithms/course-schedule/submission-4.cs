public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // we can create a graph
        // we need to check if the graph contains cycles if it doesnt we can traverse all of the courses
        if(numCourses == 0 || prerequisites.Length == 0) return true;

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

        for(int i = 0; i < numCourses; i++){
            if(visited[i] != 2){
                if(dfs(i,next,visited) == false){
                    return false;
                };
            }
        }

        return true;
    }

    private bool dfs(int curr, List<int>[] next, int[] visited){
        if(visited[curr] == 1) return false;

        visited[curr] = 1;
        bool result = true;
        foreach(var neigh in next[curr]){
            result = result && dfs(neigh, next, visited);
        }
        visited[curr] = 2;
        return result;
    }
}
