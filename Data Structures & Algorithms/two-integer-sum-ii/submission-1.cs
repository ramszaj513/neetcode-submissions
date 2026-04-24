public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int n = numbers.Length;
        var set = new Dictionary<int,int>();

        for(int i = 0; i < n; i++){
            if(set.ContainsKey(target - numbers[i])){
                return [set[target - numbers[i]] + 1, i + 1];
            }
            set[numbers[i]] = i;
        }

        return [];
    }
}
