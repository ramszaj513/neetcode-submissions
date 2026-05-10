public class Solution {
    public bool CanPartition(int[] nums) {
        // we know which sum we need to reach in the set
        // we have to see if we can reach this sum using some elements
        // if the total sum is odd we immedietly return false

        // we can create a hashset where we store the sums of the previous elements
        // if the target - curr exisits in the set we return true
        // the hashSet would have a size of target
        // we need this hashSet for each index
        // update it like this, new number the HashSet is updated with the previous values + the new one

        int n = nums.Length;
        int sum = 0;
        foreach(var number in nums) sum += number;

        if(sum % 2 != 0) return false;
        int target = sum / 2;

        bool[] sums = new bool[target];
        sums[0] = true;
        for(int i = 0; i < n; i++){
            for(int j = target - 1; j >= 0; j--){
                if(!sums[j]) continue;

                int newSum = j + nums[i];
                if(newSum > target) continue;
                if(newSum == target) return true;
                sums[newSum] = true;
            }
        } 

        return false;
    }
}
