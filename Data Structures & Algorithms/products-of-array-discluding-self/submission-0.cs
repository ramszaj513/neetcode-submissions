public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        // we create a prefix and sufix arrays
        // in the prefix array we store the multiplication of the previous elemetns excluding the current one
        // in the sufix array we store the multiplication of the upcoming elements excluding the current one
        // the value in each index is the multilication of prefix[i] and sufix[i]

        int n = nums.Length;

        int[] prefix = new int[n];
        int[] sufix = new int[n];

        prefix[0] = 1;
        prefix[1] = nums[0];
    
        sufix[n-1] = 1;
        sufix[n-2] = nums[n-1];

        for(int i = 2; i < n; i++){
            prefix[i] = prefix[i-1]*nums[i-1];
            sufix[n-i-1] = sufix[n-i]*nums[n-i];
        }

        int[] res = new int[n];

        for(int i = 0; i < n; i++){
            res[i] = prefix[i]*sufix[i];
        }

        return res;
    }
}
