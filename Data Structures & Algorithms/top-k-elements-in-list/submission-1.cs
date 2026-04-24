public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // I count each number in a hashmap
        // how to get the k most frequent elements?
        // create a bucket array where we group elements based on their frequency
        // get the k elements from the top

        var frequencies = new Dictionary<int,int>();
        int n = nums.Length;

        for(int i = 0; i < n; i++){
            if(!frequencies.ContainsKey(nums[i])){
                frequencies[nums[i]] = 1;
            }
            else{
                frequencies[nums[i]]++;
            }
        }

        List<int>[] buckets = new List<int>[n + 1];

        foreach(var (number,frequency) in frequencies){
            if(buckets[frequency]  == null){
                buckets[frequency] = new List<int>();
            }
            buckets[frequency].Add(number);
        }

        int[] results = new int[k];
        int currentK = 0;

        for(int i = n; i >= 0; i--){
            if(buckets[i] != null){
                foreach(var number in buckets[i]){
                    if(currentK == k){
                        return results;
                    }
                    results[currentK] = number;
                    currentK++;
                }
            }
        }

        return results;
    }
}
