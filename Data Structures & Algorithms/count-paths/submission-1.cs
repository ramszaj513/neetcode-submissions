public class Solution {
    public int UniquePaths(int m, int n) {
        int[] dp = new int[n];
        Array.Fill(dp,1);

        for(int i = 1; i < m; i++){
            int[] newRow = new int[n];
            newRow[0] = 1;
            for(int j = 1; j < n; j++){
                newRow[j] = newRow[j-1] + dp[j];
            }
            dp = newRow;
        }

        return dp[n-1];
    }
}
