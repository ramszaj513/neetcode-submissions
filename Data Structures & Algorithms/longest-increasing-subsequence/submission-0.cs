public class Solution {
    public int LengthOfLIS(int[] nums) {
        // naive approach check every subarray
        // O(n^3)

        // sliding window approach
        // min-value and max-value
        // starting from the maximum index we store the lis which start from that index
        // then in the smaller indexes we get the maximum of the results from the top indexes

        int n = nums.Length;
        int[] lis = new int[n];

        for(int i = n-1; i >= 0; i--){
            int best = 1;
            for(int j = i+1; j < n; j++){
                if(nums[i] < nums[j]){
                    best = Math.Max(best, lis[j]+1);
                }
            }
            lis[i] = best;
        }

        int res = 1;
        for(int i = 0; i < n; i++){
            res = Math.Max(res, lis[i]);
        }

        return res;
    }
}
