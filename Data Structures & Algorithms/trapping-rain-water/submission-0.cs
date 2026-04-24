public class Solution {
    public int Trap(int[] height) {
        // the amount of water trapped in a single cell would be:
        // the height of the min of the (two heighest pillars on the left and right which are furthest from i) - height[i]
        // we can store the best pillars and their heights, then we can in O(n) calculate the water between them

        // we go from left and right and we keep the largest value from left and from right,
        // if we encounter a larger height we save the previous largerest and go on

        int n = height.Length;

        int[] leftBest = new int[n];
        int[] rightBest = new int[n];

        int currentBest = 0;
        for(int i = 0; i < n; i++){
            if(height[i] > currentBest){
                currentBest = height[i];
            }
            leftBest[i] = currentBest;
        }

        currentBest = 0;
        for(int i = n-1; i >= 0; i--){
            if(height[i] > currentBest){
                currentBest = height[i];
            }
            rightBest[i] = currentBest;
        }

        int water = 0;
        for(int i = 0; i < n; i++){
            water += Math.Max(0, Math.Min(leftBest[i],rightBest[i]) - height[i]);
        }

        return water;
    }
}
