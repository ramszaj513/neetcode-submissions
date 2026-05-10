public class Solution {
    public int Jump(int[] nums) {
        if (nums.Length <= 1) return 0;

        int jumps = 0;
        int currentJumpEnd = 0;
        int farthestReach = 0;

        for (int i = 0; i < nums.Length - 1; i++) {
            farthestReach = Math.Max(farthestReach, i + nums[i]);

            if (i == currentJumpEnd) {
                jumps++;
                currentJumpEnd = farthestReach;
                
                if (currentJumpEnd >= nums.Length - 1) break;
            }
        }

        return jumps;
    }
}