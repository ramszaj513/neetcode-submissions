public class Solution {
    public int LargestRectangleArea(int[] heights) {
        // We have a a histogram graph where each bar has width = 1
        // we need to find rectangle where the min_height * k jest największa

        // we can go through the array from left to right and get the best result from right and left and save its height and lenght
        // then go through each height and combine the results (check if the left is better than right)

        // for each height we want to find how much we can extend it to the left
        // and how much we can extend it to the right

        int n = heights.Length;

        int[] left = new int[n]; 
        int[] right = new int[n];

        Stack<int> leftStack = new Stack<int>();
        Stack<int> rightStack = new Stack<int>();

        for(int i = 0; i < n; i++){
            while(leftStack.Count > 0 && heights[leftStack.Peek()] >= heights[i]){
                leftStack.Pop();
            }

            if(leftStack.Count == 0){
                left[i] = i + 1;
            }
            else{
                left[i] = i - leftStack.Peek();
            }
            
            leftStack.Push(i);
        }

        for(int i = n-1; i >= 0; i--){
            while(rightStack.Count > 0 && heights[rightStack.Peek()] >= heights[i]){
                rightStack.Pop();
            }

            if(rightStack.Count == 0){
                right[i] = n - i;
            }
            else{
                right[i] = rightStack.Peek() - i;
            }

            rightStack.Push(i);
        }

        int max = 0;
        for(int i = 0; i < n; i++){
            max = Math.Max(max, (left[i] + right[i] - 1) * heights[i]);
        }
        
        return max;
    }
}
