public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // [1,2,2,4] k = 3, we need to return 2 not 1

        // nlogn - sort the array then get the kth largest element
        // nlogk - min heap where the we keep current k largest elements
        // if the next number is larger than min we dequeue and enqueue

        PriorityQueue<int,int> minHeap = new PriorityQueue<int,int>();
        foreach(var num in nums){
            if(minHeap.Count < k){
                minHeap.Enqueue(num,num);
                continue;
            }

            if(num > minHeap.Peek()){
                minHeap.Dequeue();
                minHeap.Enqueue(num,num);
            }
        } 

        return minHeap.Peek();
    }
}
