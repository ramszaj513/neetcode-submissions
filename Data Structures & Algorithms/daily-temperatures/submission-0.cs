public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        // temperatures
        // [30,38,30,36,35,40,28]
        // for each day we need to calculate the number 
        // of days till the next day which is warmer
        // if such day doesnt exist then its zero

        // we add the numbers to the stack until the number is bigger than a previous one
        // if it is we update the result array until the number left on the stack
        // is larger than the one we got

        int n = temperatures.Length;
        int[] res = new int[n];

        Stack<(int val,int idx)> stack = new Stack<(int,int)>();

        for(int i = 0; i < n; i++){
            int num = temperatures[i];
            int count = 1;

            while(stack.Count > 0 && stack.Peek().val < num){
                var temp = stack.Pop();
                res[temp.idx] = i - temp.idx;
                count++;
            }

            stack.Push((num,i));
        }

        return res;
    }
}
