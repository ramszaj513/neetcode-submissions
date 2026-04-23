public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // we iterate through the nums
        // add a current element and its index to the hashmap
        // if the difference = target - nums[i] already exists in the hashmap
        // we know that the current number and the element from the hashmap add to the target

        Dictionary<int,int> hashmap = new Dictionary<int,int>();

        for(int i = 0; i < nums.Length; i++){
            if(hashmap.ContainsKey(target - nums[i])){
                return [hashmap[target - nums[i]], i];
            }
            else{
                hashmap[nums[i]] = i; 
            }
        }

        return [];
    }
}
