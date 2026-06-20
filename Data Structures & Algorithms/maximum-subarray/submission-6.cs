public class Solution {
    public int MaxSubArray(int[] nums) {
        // num - array of integers
        // goal - subarray with the largest sum
        // the integers can be negative
        // first think I am thinking of is sliding window
        // we iterate the array from left to right
        // there are 4 cases:
        // 1 - current sum is positive and the number we are getting is positive
        // 2 - current sum is negative and the number we are getting is positive
        // 3 - current sum is positive and the number we are getting is negative
        // 4 - current sum is negative and the number we are getting is negative

        // 1 - we add the number to the sum
        // 2 - we start a new sum count
        // 3 - we add the number to the sum
        // 4 - we start a new sum count 

        int max = nums[0];
        int sum = nums[0];
        for(int i = 1; i < nums.Length; i++){
            if(sum < 0){
                sum = nums[i];
            } else{
                sum += nums[i];
            }

            max = Math.Max(max, sum);
        }

        return max;
    }
}
