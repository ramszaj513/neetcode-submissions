public class KthLargest {
    PriorityQueue<int,int> heap;
    int k;

    // O(nlog(k))
    public KthLargest(int k, int[] nums) {
        heap = new PriorityQueue<int,int>();
        this.k = k;

        for(int i = 0; i < nums.Length; i++){
            if(heap.Count < k){
                heap.Enqueue(nums[i],nums[i]);
            }
            else if(heap.Peek() < nums[i]){
                heap.Dequeue();
                heap.Enqueue(nums[i],nums[i]);
            }
        }
    }
    
    // O(log(k))
    public int Add(int val) {
        if(heap.Count < k){
            heap.Enqueue(val,val);
        }
        else if(heap.Peek() < val){
            heap.Dequeue();
            heap.Enqueue(val,val);
        }

        return heap.Peek();
    }
}
