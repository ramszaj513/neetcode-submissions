public class Solution {
    public List<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        // we have an array of prerequisites
        // [ai, bi] [bi, ci] - ai and bi are prerequisite of ci
        // queries
        // [0,1] - is 0 a prerequisite of 1

        // we should create a graph
        // [a] -> [b], [d]
        // [c] -> [d]
        // [d] -> [e]

        // can the graph contain cycles?
        // if it does contain cycle what should I return?
        // I interpret it like it can contain cycles and I answer a query yes
        // in that case

        // the first idea is to 
        // for each query start with the prerequisite and traverse the graph using a DFS
        // we can reach the target it is a preqrequisite if not it isnt
        // time complexity: O(N*M)

        Dictionary<int,List<int>> next = new();
        for (int i = 0; i < numCourses; i++) {
            next[i] = new List<int>();
        }
        
        foreach (var pre in prerequisites) {
            next[pre[0]].Add(pre[1]);
        }

        bool[,] isPrereq = new bool[numCourses, numCourses];

        for (int startCourse = 0; startCourse < numCourses; startCourse++) {
            Queue<int> q = new Queue<int>();
            q.Enqueue(startCourse);
            
            while (q.Count > 0) {
                int curr = q.Dequeue();
                
                foreach (var neighbor in next[curr]) {
                    if (!isPrereq[startCourse, neighbor]) {
                        isPrereq[startCourse, neighbor] = true;
                        q.Enqueue(neighbor);
                    }
                }
            }
        }

        List<bool> res = new List<bool>();
        foreach(var query in queries){
            res.Add(isPrereq[query[0],query[1]]);
        }

        return res;
    }
}