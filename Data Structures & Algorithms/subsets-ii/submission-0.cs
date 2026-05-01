public class Solution {
    List<List<int>> res = new();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        // we go through each number and decide if we want it in the subset or not
        // the duplicates are the problem
        // we can sort the array
        // count each number decide how many do we take it and go to the next number

        Dictionary<int,int> count = new(); 
        foreach(var num in nums){
            if(!count.ContainsKey(num)) count[num] = 0;
            count[num]++;
        }

        Array.Sort(nums);
        dfs(0, new List<int>(), nums, count);
        return res;
    }

    private void dfs(int ind, List<int> curr, int[] nums, Dictionary<int,int> count){
        if(ind == nums.Length){
            res.Add(curr.ToList());
            return;
        }

        for(int i = 0; i < count[nums[ind]]; i++){
            curr.Add(nums[ind]);
        }

        int j = ind;
        while(j != nums.Length && nums[j] == nums[ind]) j++;
          
        for(int i = 0; i < count[nums[ind]]; i++){
            dfs(j, curr, nums, count);
            curr.RemoveAt(curr.Count - 1);
        }

        dfs(j, curr, nums, count);
    }
}
