public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        // 
        // we can save the longest common subsequence from the word from the start to the i
        // then when we are in the i index we can say

        int n = text1.Length;
        int m = text2.Length;
        int[,] dp = new int[n+1,m+1];
        for(int i = 0; i < m; i++) dp[0,i] = 0;
        for(int i = 0; i < n; i++) dp[i,0] = 0;

        for(int i = 1; i < n+1; i++){
            for(int j = 1; j < m+1; j++){
                if(text1[i-1] == text2[j-1]){
                    dp[i,j] = 1 + dp[i-1,j-1];
                }
                else{
                    dp[i,j] = Math.Max(dp[i,j-1],dp[i-1,j]);
                }
            }
        }

        return dp[n,m];
    }
}
