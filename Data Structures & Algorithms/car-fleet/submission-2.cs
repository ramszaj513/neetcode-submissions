public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        // n cars going in one direction
        // int position[] - of the ith car (in miles)
        // int speed[] - of the ith car (in miles / hour)

        // cars cannot pass eachother they can only be equal

        // car fleet - cars next to each other
        // how many car fleets will arrive at the destionation
        // just the number of them

        // given 2 cars can we calculate if they will meet before the target?
        // v1 and v2 where v2 is ahead of v1

        // lets sort the cars by position
        // and lets go from the left
        // add each car to a stack 
        // when a new car comes in we:
        // - check if the car behind us will be slowed down, 
        // - if so we Pop him form the stack, and push our stats
        // - if not just push current stats to the stack

        int n = position.Length;
        int[][] combined = new int[n][]; 

        for (int i = 0; i < n; i++) { 
            combined[i] = new int[] { position[i], speed[i] }; 
        } 

        Array.Sort(combined, (a, b) => a[0].CompareTo(b[0]));

        Stack<(int pos, int speed)> stack = new Stack<(int,int)>();
        for(int i = 0; i < n; i++){
            int cpos = combined[i][0];
            int cspeed = combined[i][1];

            while(stack.Count > 0 && WillSlowDown(stack.Peek().pos, stack.Peek().speed, cpos, cspeed,target)){
                stack.Pop();
            }
            
            stack.Push((cpos,cspeed));
        }

        return stack.Count;
    }

    private bool WillSlowDown(int p1, int v1, int p2, int v2, int target){
        // t1 < t2
        return ((target - p1) * v2 ) <= ((target - p2) * v1);
    }
}
