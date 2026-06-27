public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) return new int[0][];

        int max = 0;
        int min = int.MaxValue;
        foreach(var interval in intervals){
            max = Math.Max(max, interval[1]);
            min = Math.Min(min, interval[0]);
        }

        int[] starts = new int[max + 1];
        int[] ends = new int[max + 1];

        foreach(var interval in intervals){
            starts[interval[0]]++;
            ends[interval[1]]++;
        }

        List<int[]> result = new();
        
        int sum = 0;
        int currentStart = -1;

        for(int i = min; i <= max; i++){
            if(sum == 0 && starts[i] > 0){
                currentStart = i;
            }

            sum += starts[i];
            sum -= ends[i];

            if(sum == 0 && currentStart != -1 && ends[i] > 0){
                result.Add(new int[]{currentStart, i});
                currentStart = -1;
            }
        }

        return result.ToArray();
    }
}