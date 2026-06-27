public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        PriorityQueue<int, int> minHeap = new();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        
        int[][] sortedQueries = new int[queries.Length][];
        for (int i = 0; i < queries.Length; i++) {
            sortedQueries[i] = new int[] { queries[i], i };
        }
        
        Array.Sort(sortedQueries, (a, b) => a[0].CompareTo(b[0]));
        
        int[] result = new int[queries.Length];
        int j = 0;

        for (int i = 0; i < sortedQueries.Length; i++) {
            int queryVal = sortedQueries[i][0];
            int originalIdx = sortedQueries[i][1];

            while (j < intervals.Length && intervals[j][0] <= queryVal) {
                int intervalLen = intervals[j][1] - intervals[j][0] + 1;
                minHeap.Enqueue(intervals[j][1], intervalLen);
                j++;
            }

            while (minHeap.TryPeek(out var endVal, out var len) && endVal < queryVal) {
                minHeap.Dequeue(); 
            }

            if (minHeap.TryPeek(out var finalEnd, out var shortestLen)) {
                result[originalIdx] = shortestLen;
            } else {
                result[originalIdx] = -1;
            }
        }

        return result;
    }
}