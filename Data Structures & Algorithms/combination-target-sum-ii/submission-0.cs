public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {

        // we can just check every subset with an early stop condition when the sum is bigger than the target

        // bruteforce
        // to not have any duplicates in the output array we can create a hashmap to save already calculates combinations

        // but if we sort the array we know how many times we can add the number we test each combination and then just skip all of these numbers in the next
        // recurstive call

        List<List<int>> result = new List<List<int>>();
        Array.Sort(candidates);
        Dfs(0, target, new List<int>(), candidates, result);
        return result;
    }

    private void Dfs(int index, int remaining, List<int> current, int[] candidates, List<List<int>> res) {
        if (remaining == 0) {
            res.Add(new List<int>(current));
            return;
        }

        for (int i = index; i < candidates.Length; i++) {
            if (candidates[i] > remaining) break;

            // Duplicate Handling: 
            // If this isn't the first element in our loop (i > index) 
            // and it's the same as the previous one, skip it to avoid duplicate combinations.
            if (i > index && candidates[i] == candidates[i - 1]) continue;

            current.Add(candidates[i]);
            Dfs(i + 1, remaining - candidates[i], current, candidates, res);
            current.RemoveAt(current.Count - 1);
        }
    }
}
