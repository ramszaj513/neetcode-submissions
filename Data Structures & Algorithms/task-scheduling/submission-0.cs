public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // [X,X,Y,Y] n = 2
        // X Y _ X Y return 5

        // we dont care about the initial order
        // we can count each task count in a hashMap
        // X: 2, Y: 2

        // MaxHeap for the most frequent tasks
        // standard queue to track tasks which need to wait
        // if the task from the waitlist is available (we waited enough)
        // we do it
        // else start another one from the maxheap, if the maxHeap is empty 
        // we wait till we can start the next task

        Dictionary<char,int> map = new Dictionary<char,int>();
        PriorityQueue<char,int> maxHeap = new PriorityQueue<char,int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        Queue<((char task, int count), int time)> waiting = new Queue<((char, int), int)>();

        foreach(var task in tasks){
            if(!map.ContainsKey(task)){
                map[task] = 0;
            }
            map[task]++;
        }

        foreach(var entry in map){
            maxHeap.Enqueue(entry.Key, entry.Value);
        }

        int timestamp = 0;
        while(maxHeap.Count > 0 || waiting.Count > 0){
            while (waiting.Count > 0 && timestamp >= waiting.Peek().time) {
                var released = waiting.Dequeue();
                maxHeap.Enqueue(released.Item1.task, released.Item1.count);
            }

            if (maxHeap.Count > 0) {
                maxHeap.TryDequeue(out char task, out int count);
                count--;
                if (count > 0) {
                    waiting.Enqueue(((task, count), timestamp + n + 1));
                }
            }
            
            timestamp++;
        }

        return timestamp;
    }        
}
