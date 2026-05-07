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

        HashSet<int> visited = new HashSet<int>();
        HashSet<int> path = new HashSet<int>();

        for(int i = 0; i < numCourses; i++){
            if(!visited.Contains(i)){
                if(dfs(i,next,path,visited) == false){
                    return false;
                };
            }
        }

        return true;
    }

    private bool dfs(int curr, List<int>[] next, HashSet<int> path, HashSet<int> visited){
        if(path.Contains(curr)) return false;

        path.Add(curr);
        visited.Add(curr);
        bool result = true;
        foreach(var neigh in next[curr]){
            result = result && dfs(neigh, next, path, visited);
        }
        path.Remove(curr);
        return result;
    }
}
