public class Solution {
    public bool CanJump(int[] nums) {
        // nums - integer array
        // nums[i] - maximum jump length
        // check if we can reach the last index starting from 0

        // we can iterate the array from left to array
        // each time ther is a nonzero value we update the maximum reachable index

        int maxReach = 0;
        for(int i = 0; i < nums.Length; i++){
            if(i <= maxReach){
                maxReach = Math.Max(maxReach, i + nums[i]);
            }
        }

        return maxReach >= nums.Length - 1;
    }
}
