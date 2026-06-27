/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        List<int> starts = new();
        List<int> ends = new();

        foreach(var inter in intervals){
            starts.Add(inter.start);
            ends.Add(inter.end);
        }

        starts.Sort();
        ends.Sort();

        int start = 0;
        int end = 0;
        int res = 0;
        int maxRes = 0;

        while(start < intervals.Count){
            if(starts[start] < ends[end]){
                res++;
                start++;
            } else{
                res--;
                end++;
            }

            maxRes = Math.Max(maxRes, res);
        }

        return maxRes;
    }
}
