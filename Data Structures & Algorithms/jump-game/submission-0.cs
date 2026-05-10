public class Solution {
    public bool CanJump(int[] nums) {
        // the problem here is the decision where to go when the length is > 1
        // from each index mark the next k indexes as reachable
        // then go to the next index, if its not reachable return false
        // O(n*k)

        // i k steps
        // 5 1 2 2 0 0 0 1

        // O(n) time
        // O(1) space
        int maxReach = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            if (i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);
            if (maxReach >= nums.Length - 1) return true;
        }
        
        return true;
    }
}
