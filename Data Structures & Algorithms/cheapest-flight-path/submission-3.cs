public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // n - airports 0 - n-1
        // flights - represent one-way flight from airport from -> to with price
        // src - starting airport
        // dst - destination airport
        // k - maximum number of stops i can make
        // I want to return the cheapest price from src to dst

        // O(k*E + n)

        int[] cost = new int[n];
        for(int i = 0; i < n; i++){
            cost[i] = int.MaxValue;
        }
        cost[src] = 0;

        for(int i = 0; i <= k; i++){
            int[] newCost = (int[])cost.Clone();

            foreach(var flight in flights){
                int start = flight[0];
                int end = flight[1];
                int w = flight[2];

                if (cost[start] == int.MaxValue)
                    continue;

                if(cost[start] + w < newCost[end]){
                    newCost[end] = cost[start] + w;
                }
            }
            cost = newCost;
        }

        return cost[dst] == int.MaxValue ? -1 : cost[dst];
    }
}
