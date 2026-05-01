public class Solution {
    List<List<int>> res = new();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        // we go through each number and decide if we want it in the subset or not
        // the duplicates are the problem
        // we can sort the array
        // count each number decide how many do we take it and go to the next number

        Array.Sort(nums);
        Backtrack(0, new List<int>(), nums);
        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        if (i == nums.Length) {
            res.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(i + 1, subset, nums);
        subset.RemoveAt(subset.Count - 1);

        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) {
            i++;
        }
        Backtrack(i + 1, subset, nums);
    }
}
