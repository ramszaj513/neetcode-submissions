public class Solution {
    public int MaxProfit(int[] prices) {
        int min = prices[0];
        int max = prices[0];
        int best = 0;

        for(int i = 0; i < prices.Length; i++){
            if(prices[i] > max){
                max = prices[i];
            }
            if(prices[i] < min){
                min = prices[i];
                max = 0; 
            }

            if(max - min > best){
                best = max - min;
            }
        }

        return best;
    }
}
