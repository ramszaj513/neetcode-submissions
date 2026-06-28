public class Solution {
    public double[] CalcEquation(List<List<string>> equations, double[] values, List<List<string>> queries) {
        // equations Ai / Bi = values[i]
        // queries -> Cj/ Dj

        // so basicly the Ai,Bi,Cj,Dj are just strings
        // and variable names, from that I conclude that the values
        // in queries are variables from equations

        // A / B = values[i]
        // B / C = values[k]
        // C / D = values[j]

        // A / B -> values[i]
        // A / D -> values[i] * values[k] * values[j]

        // if the given variable name doesnt exist in the graph return -1
        // if there is no correct path return -1

        // we create a directed graph where edges are from A to B
        // if we can find the path from C to D the result is the calculation
        // of all of the values (the values can be on the edges(i guess))
        // time complexity -> O(M*N)

        var map = new Dictionary<string,List<(string, double)>>();
        for(int i = 0; i < equations.Count; i++){
            var name1 = equations[i][0];
            var name2 = equations[i][1];

            if(!map.ContainsKey(name1)){
                map[name1] = new List<(string, double)>();
            }
            if(!map.ContainsKey(name2)){
                map[name2] = new List<(string, double)>();
            }
            map[name1].Add((name2,values[i]));
            map[name2].Add((name1,1.0 / values[i]));
        }

        double Dfs(string start, string target, HashSet<string> visited){
            if (start == target) return 1.0;

            visited.Add(start);

            foreach(var (name,val) in map[start]){
                if(!visited.Contains(name)){
                    double result = Dfs(name, target, visited);
                    if(result != -1.0) return val*result;
                }
            }

            return -1.0;
        }

        double[] res = new double[queries.Count];
        for(int i = 0; i < queries.Count; i++){
            string start = queries[i][0];
            string target = queries[i][1];

            if(!map.ContainsKey(start) || !map.ContainsKey(target)){
                res[i] = -1.0;
                continue;
            }

            HashSet<string> visited = new();
            res[i] = Dfs(start,target,visited);
        }

        return res;
    }
}