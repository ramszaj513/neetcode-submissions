public class Solution {
    public int MaxProfit(int[] prices) {
        // we can check the profit from each pair of the array
        // save it in a 2D array, as start end
        // save the current profit for a given index then when iterating 
        // look at the previous profit and update accordingly

        // [1,3,4,0,4]
        // 1, 2, 3, 3

        // two dimentional array 
        // - dp[i,0] represents the max value we can get when we are in the buying state
        // - dp[i,1] represents the max value we can get when we are in the selling state

        // each time we get the best outcome of both states
        // when in buying:
        // - buy (so we check the best result from the selling table one day in the future minus our price)
        // - wait (we check the best result when we are in buying one day in the future)

        // when in selling
        // - sell (so we check the best result from the buying two days in the future current price or just out price if we cant but in the future)
        // - wait (we check what is the result of buying)

        int n = prices.Length;
        int[,] dp = new int[n + 1, 2];

        for (int i = n - 1; i >= 0; i--) {
            for (int buying = 1; buying >= 0; buying--) {
                if (buying == 1) {
                    int buy = dp[i + 1, 0] - prices[i];
                    int cooldown = dp[i + 1, 1];
                    dp[i, 1] = Math.Max(buy, cooldown);
                } else {
                    int sell = (i + 2 < n) ? dp[i + 2, 1] + prices[i] : prices[i];
                    int cooldown = dp[i + 1, 0];
                    dp[i, 0] = Math.Max(sell, cooldown);
                }
            }
        }

        return dp[0, 1];
    }
}
