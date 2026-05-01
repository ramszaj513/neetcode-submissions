public class Solution {
    private List<List<int>> res = new List<List<int>>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(0, new List<int>(), nums);
        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        res.Add(new List<int>(subset));
        for (int j = i; j < nums.Length; j++) {
            if (j > i && nums[j] == nums[j - 1]) {
                continue;
            }
            subset.Add(nums[j]);
            Backtrack(j + 1, subset, nums);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
