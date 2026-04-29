public class Solution {
    public int LastStoneWeight(int[] stones) {
        // we have the weights of stones
        // we choose the two heaviest stones and smash them together

        // O(nlogn)

        PriorityQueue<int,int> heap = new PriorityQueue<int,int>(Comparer<int>.Create((a,b)=> b.CompareTo(a)));

        foreach(var stone in stones) { heap.Enqueue(stone,stone); }
        while(heap.Count > 1){
            int stone1 = heap.Dequeue();
            int stone2 = heap.Dequeue();
            if(stone1 != stone2){ heap.Enqueue(stone1 - stone2, stone1 - stone2); }
        }

        return heap.Count == 0 ? 0 : heap.Dequeue();
    }
}
