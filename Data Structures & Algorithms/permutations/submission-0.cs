public class Solution {
    List<List<int>> res = new();
    Dictionary<int,bool> visited = new Dictionary<int,bool>();

    public List<List<int>> Permute(int[] nums) {
        // we keep the nums in a HashSet
        // we either add it now or later
        // we add it now continue if it added now
        // we add it later and continue we the next number
        foreach(var num in nums){
            visited[num] = false;
        }
        dfs(new List<int>(), nums);
        return res;
    }

    private void dfs(List<int> current, int[] nums){
        if(current.Count == nums.Length){
            res.Add(current.ToList());
            return;
        }

        for(int i = 0; i < nums.Length; i++){
            if(visited[nums[i]] == false){
                visited[nums[i]] = true;
                current.Add(nums[i]);
                dfs(current,nums);
                visited[nums[i]] = false;
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
