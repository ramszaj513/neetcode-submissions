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

        // 6 6 6 6
        // 6 5 4 4
        //

        int n = nums.Length;

        // HEAP SOLUTION:

        // var maxHeap = new PriorityQueue<(int val,int idx), int>(
        //     Comparer<int>.Create((a, b) => b.CompareTo(a))
        // );

        // int[] res = new int[n - k + 1];

        // for(int r = 0; r < n; r++){
        //     maxHeap.Enqueue((nums[r], r), nums[r]);

        //     if(r >= k - 1){
        //         while (maxHeap.Peek().idx < r - k + 1) {
        //             maxHeap.Dequeue();
        //         }

        //         res[r - k + 1] = maxHeap.Peek().val;
        //     }
        // }

        // return res;

        // MONOTHONIC QUEUE:

        // [6 5 3] 4
        // 6 [5 3 4]

        int[] output = new int[n - k + 1];
        var q = new LinkedList<int>();
        int l = 0, r = 0;

        while (r < n) {
            while (q.Count > 0 && nums[q.Last.Value] < nums[r]) {
                q.RemoveLast();
            }
            q.AddLast(r);

            if (l > q.First.Value) {
                q.RemoveFirst();
            }

            if ((r + 1) >= k) {
                output[l] = nums[q.First.Value];
                l++;
            }
            r++;
        }

        return output;

    }
}
