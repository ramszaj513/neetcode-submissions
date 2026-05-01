public class MedianFinder {
    // we can keep the current median
    // on each insert we do a binary search to insert the value
    // and then we update the median based on which half the value landed in
    // 1 1 1 2 3

    // we can keep two heaps one with the values above the median
    // and one we the values below it

    // minHeap above the median
    // maxHeap below the median

    // we can assume that median is always the min element in the min heap
    // insert -> we check if the  value is larger or smaller than the current median
    // we insert it into a correct heap, if the left heap has the same count as the right the median is mean
    // if the left heap has more count than right we deque from left and add to right
    // if the right is more than 1 longer than right we deque from right and insert to the left
    // find -> minHeap.Peek();

    PriorityQueue<int,int> leftHeap;
    PriorityQueue<int,int> rightHeap;

    public MedianFinder() {
        leftHeap = new PriorityQueue<int,int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        rightHeap = new PriorityQueue<int,int>();
    }
    
    // log(n/2)
    public void AddNum(int num) {
        if(rightHeap.Count == 0 || rightHeap.Peek() <= num){
            rightHeap.Enqueue(num,num);
        } else{
            leftHeap.Enqueue(num,num);
        }

        if(rightHeap.Count > leftHeap.Count + 1){
            var numFromRight = rightHeap.Dequeue();
            leftHeap.Enqueue(numFromRight,numFromRight);
        } else if(leftHeap.Count > rightHeap.Count){
            var numFromLeft = leftHeap.Dequeue();
            rightHeap.Enqueue(numFromLeft,numFromLeft);
        }
    }
    
    // O(1)
    public double FindMedian() {
        if(rightHeap.Count == leftHeap.Count){
            return ((double)leftHeap.Peek() + (double)rightHeap.Peek()) / 2;
        } else{
            return (double)rightHeap.Peek();
        }
    }
}
