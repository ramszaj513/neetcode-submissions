public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        int res = n;

        for(int i = 0; i < n - 1; i++){
            // odd case
            int k = 1;
            while(i - k >= 0 && i + k < n && s[i-k] == s[i+k]){
                res++;
                k++;
            }
            
            if(s[i] != s[i+1]) continue;

            res++;
            // even case
            k = 1;
            while(i - k >= 0 && i + 1 + k < n && s[i-k] == s[i+1+k]){
                res++;
                k++;
            }
        }

        return res;
    }
}
