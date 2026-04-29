public class Solution {
    public int LastStoneWeight(int[] stones) {
        // we have the weights of stones
        // we choose the two heaviest stones and smash them together

        // O(nlogn)

        // PriorityQueue<int,int> heap = new PriorityQueue<int,int>(Comparer<int>.Create((a,b)=> b.CompareTo(a)));
        // foreach(var stone in stones) { heap.Enqueue(stone,stone); }

        // while(heap.Count > 1){
        //     int stone1 = heap.Dequeue();
        //     int stone2 = heap.Dequeue();
        //     if(stone1 != stone2){ heap.Enqueue(stone1 - stone2, stone1 - stone2); }
        // }

        // return heap.Count == 0 ? 0 : heap.Dequeue();

        // O(n + m), where m is weight of the heaviest stone
        // sort the values using a bucket sort O(n)
        // then go from top if the buckets contains only 1 value we go search for the next bucket
        // add the difference 
        // finish when on the last bucket
        int[] buckets = new int[101];
        for(int i = 0; i < 101; i++) buckets[i] = 0;
        int max = -1;
        foreach(var stone in stones){
            buckets[stone]++;
            max = Math.Max(max, stone);
        }

        int first = max, second = max;
        while (first > 0) {
            if (buckets[first] % 2 == 0) {
                first--;
                continue;
            }

            int j = Math.Min(first - 1, second);
            while (j > 0 && buckets[j] == 0) {
                j--;
            }

            if (j == 0) {
                return first;
            }

            second = j;
            buckets[first]--;
            buckets[second]--;
            buckets[first - second]++;
            first = Math.Max(first - second, second);
        }

        return first;
    }
}
