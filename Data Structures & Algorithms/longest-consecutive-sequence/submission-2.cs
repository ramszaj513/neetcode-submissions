public class Solution {
    public int LongestConsecutive(int[] nums) {
        // [2,20,4,10,3,4,5]
        // [set: 2,20,4,10,3,5]
        // identify the starting numbers (num - 1 doesn't exist in the array)
        // List<int> starts
        // maxSequenceLenght

        if(nums.Length == 0){
            return 0;
        }

        var set = new HashSet<int>();
        foreach(int num in nums){
            set.Add(num);
        }

        List<int> starts = new List<int>();

        foreach(int num in set){
            if(!set.Contains(num - 1)){
                starts.Add(num);
            }
        }

        int maxLength = 1;

        foreach(int start in starts){
            int num = start + 1;
            int currentLength = 1;

            while(set.Contains(num++)){
                currentLength++;
                if(currentLength > maxLength){
                    maxLength = currentLength;
                }
            }
        }

        return maxLength;
    }
}
