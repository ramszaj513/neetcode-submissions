public class Solution {
    public int MaxArea(int[] heights) {
        // water = (j-i) * min(heights[i],heights[j])
        // we use the two pointers approach
        // we move the pointer with the smaller heigth, bacause there is no point in moving the pointer with bigger height
        // even if we found some height which is bigger the minimum of the two would be still equal to the smaller height

        int n = heights.Length;
        int left = 0;
        int right = n-1;

        int maxWater = 0;
        int bestHeight = 0;

        while(left < right){
            int height;
            if(heights[left] < heights[right]){
                height = heights[left];
            } else{
                height = heights[right];
            }

            if(height > bestHeight){
                int water = height * (right - left);
                if(water > maxWater) {
                    maxWater = water;
                    bestHeight = height;
                }
            }
            
            if(heights[left] > heights[right]){
                right--;
            }
            else{
                left++;
            }
        }
        
        return maxWater;
    }
}
