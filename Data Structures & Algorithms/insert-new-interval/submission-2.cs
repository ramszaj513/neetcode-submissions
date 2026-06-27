public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int n = intervals.Length;
        List<int[]> result = new();
        bool newAdded = false;

        for(int i = 0; i < n; i++){
            // not everlapping at the start
            if(intervals[i][1] < newInterval[0]){
                result.Add(intervals[i]);
            }
            // right after the newInterval
            else if(intervals[i][0] > newInterval[1]){
                if(!newAdded){
                    result.Add(newInterval);
                    newAdded = true;
                }
                
                result.Add(intervals[i]);
            }
            else {
                // Merge the current interval into newInterval
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
        }

        if(!newAdded) result.Add(newInterval);

        return result.ToArray();
    }
}
