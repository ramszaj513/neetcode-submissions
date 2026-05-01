public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        // we choose to add a number
        // resursivly call it on the next number with the current list of numbers
        // we choose not to add a number
        // resursivly call on the next number with the current list of numbers
        // time complexity: n*2^n
        // space complexity: 2^n

        List<List<int>> res = new();

        void Backtrack(int index, List<int> subset){
            if(index > nums.Length - 1){
                res.Add(new List<int>(subset));
                return;
            }

            // add the current number to the subset
            subset.Add(nums[index]);
            Backtrack(index + 1, subset);

            // dont add the current number to the subset
            subset.RemoveAt(subset.Count - 1);
            Backtrack(index + 1, subset);
        }


        Backtrack(0,new List<int>());
        return res;
    }
}
