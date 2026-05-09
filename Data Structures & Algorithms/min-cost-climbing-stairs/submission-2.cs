public class Solution {
    // bottom - up
    // public int MinCostClimbingStairs(int[] cost) {
    //     int n = cost.Length;
    //     int[] dp = new int[n + 1];

    //     for (int i = 2; i <= n; i++) {
    //         dp[i] = Math.Min(dp[i - 1] + cost[i - 1],
    //                          dp[i - 2] + cost[i - 2]);
    //     }

    //     return dp[n];
    // }

    // up - bottom
    public int MinCostClimbingStairs(int[] cost) {
        for (int i = cost.Length - 3; i >= 0; i--) {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }
        return Math.Min(cost[0], cost[1]);
    }
}
