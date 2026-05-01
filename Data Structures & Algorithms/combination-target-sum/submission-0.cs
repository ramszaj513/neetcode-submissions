public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> res = new();
        Backtrack(0,0,target,nums,new List<int>(), res);
        return res;
    }

    // get the current number
    // we decide how many times should we add it to the sum
    // for each number of times we call the logic on the next number with the chosen number of times and sum
    private void Backtrack(int index, int sum, int target, int[] nums, List<int> current, List<List<int>> res){
        if(sum > target) return;
        if(index == nums.Length){
            if(sum == target) res.Add(new List<int>(current));
            return;
        }

        // add k times
        int newSum = sum;
        while(newSum < target){
            newSum += nums[index];
            current.Add(nums[index]);
        }
        while(newSum != sum){
            Backtrack(index + 1, newSum, target, nums, current, res);
            current.RemoveAt(current.Count - 1);
            newSum -= nums[index];
        }

        // add 0 times
        Backtrack(index + 1, sum, target, nums, current, res);
    }
}
