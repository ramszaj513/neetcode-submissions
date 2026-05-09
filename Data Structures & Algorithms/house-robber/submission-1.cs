public class Solution {
    // public int Rob(int[] nums) {
    //     // i houses
    //     // we are in the ith house
    //     // we know the values from the ith -1 and ith -2
    //     // min(i-2 + i, i-1)

    //     int n = nums.Length;
    //     if(n == 1) return nums[0];

    //     int[] dp = new int[n+1];
    //     dp[0] = 0;
    //     dp[1] = nums[0];
        
    //     for(int i = 2; i < n+1; i++){
    //         dp[i] = Math.Max(dp[i-2] + nums[i-1], dp[i-1]);
    //     }

    //     return dp[n];
    // }

    // if we can use the input array
    public int Rob(int[] nums) {
        if(nums.Length == 1) return nums[0];

        nums[1] = Math.Max(nums[0],nums[1]);
        for(int i = 2; i < nums.Length; i++){
            nums[i] = Math.Max(nums[i-2] + nums[i],nums[i-1]);
        }

        return nums[nums.Length-1];
    }
}
