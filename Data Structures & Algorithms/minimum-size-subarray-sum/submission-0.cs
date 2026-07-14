public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        // positive integers nums
        // positove integer target
        // minimal length of the subarray where sum is greater than or equal to target
        // if there no such subarray return 0
        
        // I would do it like this
        // each time store indices of start and end of the window
        // increase end until the sum is correct then
        // remove first value then increase end until correct etc. if its still correct continue with the front

        int start = 0;
        int end = 0;
        int best = int.MaxValue;
        int sum = 0;

        while(end != nums.Length && start != nums.Length){
            while(sum < target && end != nums.Length){
                sum += nums[end];
                end++;
            }

            while(sum >= target && start != nums.Length){
                best = Math.Min(end - start, best);

                sum -= nums[start];
                start++;
            }
        }

        return best == int.MaxValue ? 0 : best;
    }
}