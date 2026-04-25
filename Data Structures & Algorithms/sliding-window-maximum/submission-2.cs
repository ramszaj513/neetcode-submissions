public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // int max;
        // new number:
        // - is larger than max -> update max, initilize its count to 1
        // - is smaller than max ->
        //      if the max didnt leave then fine
        //      if the max left check the count of the max value:
        //          if the count of the max value is larger than zero then nice
        //          if the number of the max value is zero??
        // 
        // ??         
        // [6 5 3] 4
        // 6 [5 3 4]

        int n = nums.Length;

        var maxHeap = new PriorityQueue<(int val,int idx), int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        int[] res = new int[n - k + 1];

        for(int r = 0; r < n; r++){
            maxHeap.Enqueue((nums[r], r), nums[r]);

            if(r >= k - 1){
                while (maxHeap.Peek().idx < r - k + 1) {
                    maxHeap.Dequeue();
                }

                res[r - k + 1] = maxHeap.Peek().val;
            }
        }

        return res;
    }
}
