public class Solution {
    public int LengthOfLIS(int[] nums) {
        // naive approach check every subarray
        // O(n^3)

        // dynamic programming
        // starting from the maximum index we store the lis which start from that index
        // then in the smaller indexes we get the maximum of the results from the top indexes
        // O(n^2), O(n)

        int n = nums.Length;
        int[] lis = new int[n];
        int max = 1;

        for(int i =0; i < n; i++){
            int best = 1;
            for(int j = 0; j < i; j++){
                if(nums[i] <= nums[j]) continue;
                best = Math.Max(best, lis[j]+1);
            }
            lis[i] = best;
            max = Math.Max(max,best);
        }

        return max;
    }
}
