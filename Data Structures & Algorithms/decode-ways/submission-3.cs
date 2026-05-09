public class Solution {
    public int NumDecodings(string s) {
        int[] dp = new int[s.Length + 1];
        dp[s.Length] = 1;
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '0') {
                dp[i] = 0;
            } else {
                dp[i] = dp[i + 1];
                if (i + 1 < s.Length && (s[i] == '1' ||
                    s[i] == '2' && s[i + 1] < '7')) {
                    dp[i] += dp[i + 2];
                }
            }
        }
        return dp[0];
    }
}
