public class Solution {
    public int Search(int[] nums, int target) {
        // O(n)

        // O(log(n)) - search for the min
        // decide which part
        // O(log(n)) - search for the element

        int l = 0;
        int r = nums.Length - 1;

        if(nums.Length == 1) return (nums[0] == target ? 0 : -1);

        while(l <= r){
            int mid = l + (r-l)/2;

            if(nums[mid] == target) return mid;

            if (nums[l] <= nums[mid]) {
                if (target >= nums[l] && target < nums[mid]) {
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            }
            else {
                if (target > nums[mid] && target <= nums[r]) {
                    l = mid + 1;
                } else {
                    r = mid - 1;
                }
            }
        }

        return -1;
    }
}
