public class Solution {
    public int Rob(int[] nums) {
        // lets calculate the max number where we include the first house
        // and then calcualte the solution when we include the second house
        // get the maximum of these solution 

        if(nums.Length == 1) return nums[0];
        return Math.Max(max(nums[1..]),max(nums[..^1]));
    }

    private int max(int[] nums){
        int n = nums.Length;

        int[] dp = new int[n+1];
        dp[0] = 0;
        dp[1] = nums[0];
        
        for(int i = 2; i < n+1; i++){
            dp[i] = Math.Max(dp[i-2] + nums[i-1], dp[i-1]);
        }

        return dp[n];
    }
}
