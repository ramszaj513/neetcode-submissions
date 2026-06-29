public class Solution {
    public int IntegerBreak(int n) {
        // int n
        // break it into positive integers
        // a + b + c ..  = n
        // a*b*C .. >>

        // find all of the possible ways to sum the numbers up
        // (n n) + (n n-1) + (n n-2) + .. (n 1)
        // n! / k! (n-k)!

        // foreach -> check the product   

        // 1 2 3
        // 1 -> 1
        // 2 -> max(2, dp[])
        // 

        // i number

        // i-1 + 1, i-2 + 2 i-n-1 + n-1 etc.
        // i, dp[i-1]*1, dp[i-2]*2 etc.

        // O(1 + 2 + 3 + 4 + 5 ) -> (n)(n-1) / 2 -> O(n^2)
        
        // 3
        // 0 1 1 0 0 
        // 2 + 1

        int[] dp = new int[n+1];
        dp[1] = 1;

        for(int target = 2; target <= n; target++){
            int maxProduct = 0;
            for(int i = 1; i < target; i++){
                maxProduct = Math.Max(Math.Max(maxProduct, (target - i) * dp[i]), (target-i)*i);
            }
            dp[target] = maxProduct;
        }

        return dp[n];
    }
}