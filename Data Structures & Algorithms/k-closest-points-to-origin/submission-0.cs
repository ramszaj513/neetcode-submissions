public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        // we can calculate distance of each pair and put them int a minheap
        // then at the end get the first k elements
        // that would be a O(nlog(k)) solution and O(k) memory

        PriorityQueue<int[],int> queue = new PriorityQueue<int[],int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        
        foreach(var point in points){
            int distance = point[0]*point[0] + point[1]*point[1];

            if(queue.Count < k){
                queue.Enqueue(new int[2]{point[0],point[1]}, distance);
                continue;
            }
            
            queue.TryPeek(out _, out int maxDistance);
            if(maxDistance > distance){
                queue.Enqueue(new int[2]{point[0],point[1]}, distance);
                queue.Dequeue();
            }
        }

        List<int[]> res = new List<int[]>();
        while(queue.Count > 0){
            res.Add(queue.Dequeue());
        } 

        return res.ToArray();
    }
}
