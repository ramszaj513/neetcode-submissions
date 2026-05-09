public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int[] current = new int[n];

        current[0] = cost[0];
        current[1] = cost[1];
        for(int i = 2; i < n; i++){
            current[i] = Math.Min(current[i-1], current[i-2]) + cost[i];
        }

        return Math.Min(current[n-2],current[n-1]);
    }
}
