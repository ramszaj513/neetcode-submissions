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
        foreach(var pre in prerequisites){
            if(!next.ContainsKey(pre[0])){
                next[pre[0]] = new List<int>();
            }
            next[pre[0]].Add(pre[1]);
        }

        List<bool> res = new List<bool>();
        Stack<int> stack = new();
        HashSet<int> visited = new();

        foreach(var query in queries){
            stack.Push(query[0]);
            visited.Add(query[0]);
            int target = query[1];
            bool isFound = false;

            while(stack.Count > 0){
                var node = stack.Pop();

                if(target == node){
                    isFound = true;
                    break;
                }

                if(next.ContainsKey(node)){
                    foreach(var neigh in next[node]){
                        if(visited.Contains(neigh)) continue;
                        stack.Push(neigh);
                        visited.Add(neigh);
                    }
                }
            }

            res.Add(isFound);
            stack.Clear();
            visited.Clear();
        }

        return res;
    }
}