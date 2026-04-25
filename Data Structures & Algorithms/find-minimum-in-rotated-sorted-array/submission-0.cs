public class Solution {
    public int FindMin(int[] nums) {
        // increasing numbers _  min  _ increasing numbers
        // increasing numbers _  min
        // min _ increasing numbers

        // naive would be O(n)

        // nnnnnnnn _  min  _ nn _ mid _ nnnnnnnnnnnnnnnnnn

        // [3,4,5,6,1,2]

        int n = nums.Length;
        int l = 0;
        int r = n - 1;

        while(l < r){
            int mid = l + (r - l)/2;

            if(nums[mid] < nums[r]){
                r = mid;
            }
            else{
                l = mid + 1;
            }
        }
        
        return nums[l];
    }
}
