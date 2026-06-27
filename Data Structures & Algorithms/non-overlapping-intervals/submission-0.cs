public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        // [1,2] [2,3] -> not overlapping
        // we can map the intervals into a timeline

        // this is a greedy problem 100%

        // each time there are collisions we know what is the best choice to remove

        // we want to remove segments which are colliding with the biggest number of elements

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        int prevEnd = intervals[0][1];
        int result = 0;

        for(int i = 1; i < intervals.Length; i++){
            // check if it overlaps
            if(intervals[i][0] >= prevEnd){
                prevEnd = intervals[i][1];
            }
            else{
                result++;
                if(prevEnd > intervals[i][1]){
                    prevEnd = intervals[i][1];
                }
            }
        }

        return result;
    }
}
