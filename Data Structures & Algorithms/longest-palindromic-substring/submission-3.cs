public class Solution {
    public string LongestPalindrome(string s) {
        // go through each index
        // try to expand the palindrome
        // odd, even: (i), (i,i+1)

        // ababd

        int n = s.Length;
        int resStart = 0;
        int resLen = 1;

        for(int i = 0; i < n - 1; i++){
            // odd case
            int k = 1;
            while(i - k >= 0 && i + k < n && s[i-k] == s[i+k]){
                k++;
            }

            if(1 + 2*(k-1) > resLen){
                resStart = i - k + 1;
                resLen = 1 + 2*(k-1);
            }
            
            if(s[i] != s[i+1]) continue;

            // even case
            k = 1;
            while(i - k >= 0 && i + 1 + k < n && s[i-k] == s[i+1+k]){
                k++;
            }
            if(2 + 2*(k-1) > resLen){
                resStart = i - k + 1;
                resLen = 2 + 2*(k-1);
            }
        }

        return s.Substring(resStart, resLen);
    }
}
