public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        // we go thourgh each index and check if any word matches the current index
        // then we jump to every end of the matching indexes and repeat the process
        // we can keep an array of true-false, go to one index and mark the ends of the matching words as true
        // go later if there is false we skip the index, if there is true we reapeat the process
        // O(n*m*t)
        // if use a hashmap we remove the redundant comaprisions 
        // thath would be a O(n*t) solution, we just check 
        int n = s.Length;
        int k = 0;

        HashSet<string> set = new HashSet<string>();
        foreach(var word in wordDict){
            set.Add(word);
            k = Math.Max(k, word.Length);
        }

        bool[] dp = new bool[n+1];
        dp[0] = true;

        for(int i = 0; i < n; i++){
            if(!dp[i]) continue;
            for (int end = i + 1; end <= n; end++) {
                if(end - i > k) break;
                string word = s.Substring(i, end - i);
                if (set.Contains(word)) {
                    dp[end] = true;
                }
            }
        }

        return dp[n];
    }
}
