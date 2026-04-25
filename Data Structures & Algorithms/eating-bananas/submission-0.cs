public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // pieles of bananas
        // h - how fast i have to eat the bananas
        // i can decide the per hour eating rate k

        // each hour:
        // which pile is eaten (I can only eat in that pile ofr this hour)

        // minimum k such that bananas can be eaten

        // piles = [1,4,3,2], h = 9

        // o(n^2)
        // iterate through k, starting from the k = max.Value to k = 1;
        // if the number of hours required is too large we return the previous value

        // O(nlog(m)), where m is the max value in the array

        int n = piles.Length;
        int max = 0;

        foreach(int num in piles){
            max = Math.Max(max,num);
        }
        
        int r = max;
        int l = 1;

        while(l < r){
            int mid = l + (r-l)/2;

            int hours = 0;
            for(int i = 0; i < n; i++){
                hours += ((piles[i] % mid == 0) ? piles[i]/mid : piles[i]/mid + 1);
            }

            if(hours > h){
                l = mid + 1;
            } else{
                r = mid;
            }
        }

        return l; 
    }
}
