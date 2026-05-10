public class Solution {
    public int MaxSubArray(int[] nums) {
        // sliding window approach

        int currSum = nums[0];
        int max = nums[0];

        for(int r = 1; r < nums.Length; r++){
            if(currSum < 0){
                currSum = nums[r];
            } else{
                currSum += nums[r];
            }

            max = Math.Max(max,currSum);
        }    

        return max;
    }
}
