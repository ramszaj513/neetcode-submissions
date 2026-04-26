public class Solution {
    public int FindDuplicate(int[] nums) {
        // 1 7 2 3 4 5 6 7
        int slow = 0;
        int fast = 0;

        while(true){
            slow = nums[slow];
            fast = nums[nums[fast]];
            if(slow == fast){
                break;
            }
        }

        int slowStart = 0;
        while(true){
            slow = nums[slow];
            slowStart = nums[slowStart];
            if(slowStart == slow){
                return slow;
            }
        }

        return -1;
    }
}
