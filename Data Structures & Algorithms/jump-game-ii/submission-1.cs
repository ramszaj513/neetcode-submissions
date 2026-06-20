public class Solution {
    public int Jump(int[] nums) {
        int l = 0;
        int r = 0;
        int moves = 0;
        int maxRange = nums[0];
        while(r < nums.Length - 1){
            maxRange = Math.Max(maxRange, l + nums[l]);

            if(l == r){
                l = r + 1;
                r = maxRange;
                moves++;
                continue;
            }

            l++;
        }

        return moves;
    }
}
