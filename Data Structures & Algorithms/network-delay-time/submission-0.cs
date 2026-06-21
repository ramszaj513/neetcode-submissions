public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k){
    
        Dictionary<int, List<(int neigh, int time)>> edges = new();
        for (int i = 1; i <= n; i++){
            edges[i] = new List<(int, int)>();
        }
        
        foreach (var time in times) {
            edges[time[0]].Add((time[1], time[2]));
        }

        int[] dist = new int[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[k] = 0;

        PriorityQueue<(int node, int distance), int> pq = new();
        pq.Enqueue((k, 0), 0);

        while (pq.Count > 0) {
            var curr = pq.Dequeue();
            int u = curr.node;
            int currentDist = curr.distance;

            if (currentDist > dist[u]) continue;

            foreach (var edge in edges[u]) {
                int v = edge.neigh;
                int weight = edge.time;

                if (dist[u] + weight < dist[v]) {
                    dist[v] = dist[u] + weight;
                    pq.Enqueue((v, dist[v]), dist[v]);
                }
            }
        }

        int maxTime = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[i] == int.MaxValue) {
                return -1; 
            }
            maxTime = Math.Max(maxTime, dist[i]);
        }

        return maxTime;
    }
}
