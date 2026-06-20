public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        // we have n gas stations each one has gas and cost to reach next station
        // car can store an infinite number of gas
        // we need to find the starting point which allows to travel the gas stations

        // (1,2) -> (5,3) -> (2,3)

        // gas > cost

        // -1 +2 -1

        if(gas.Sum() - cost.Sum() < 0) return -1;
        
        int total = 0;
        int start = 0;
        int i = 0;
        int count = 0;

        while(true){
            total += gas[i] - cost[i];
            if(total < 0){
                total = 0;
                start = (i+1) % gas.Length;
                count = 0;
            }

            if(count == gas.Length){
                break;
            }

            i = (i+1) % gas.Length;
            count++;
        }

        return start;
    }
}
