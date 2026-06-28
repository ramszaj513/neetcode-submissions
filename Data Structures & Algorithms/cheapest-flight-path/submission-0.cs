public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // n - airports 0 - n-1
        // flights - represent one-way flight from airport from -> to with price
        // src - starting airport
        // dst - destination airport
        // k - maximum number of stops i can make
        // I want to return the cheapest price from src to dst

        // we can create a graph demonstrating the airports and the cost between them
        // O(k*E + n)

        var adj = new List<(int,int)>[n];
        for(int i = 0; i < n; i++){
            adj[i] = new List<(int,int)>();
        }
        foreach(var flight in flights){
            adj[flight[0]].Add((flight[1], flight[2]));
        }

        int[] cost = new int[n];
        for(int i = 0; i < n; i++){
            cost[i] = int.MaxValue;
        }
        cost[src] = 0;

        for(int i = 0; i <= k; i++){
            int[] newCost = (int[])cost.Clone();
            for(int j = 0; j < n; j++){
                foreach(var (neigh,w) in adj[j]){

                    if (cost[j] == int.MaxValue)
                        continue;

                    if(cost[j] + w < cost[neigh]){
                        newCost[neigh] = cost[j] + w;
                    }
                }
            }
            cost = newCost;
        }

        return cost[dst] < int.MaxValue ? cost[dst] : -1;
    }
}
