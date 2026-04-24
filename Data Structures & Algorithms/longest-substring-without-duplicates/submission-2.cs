public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // longest string without duplicate characters

        // O(n) O(m) - hashset

        var map = new Dictionary<char,int>();

        int longest = 0;
        int left = 0;

        for(int i = 0; i < s.Length; i++){
            char c = s[i];

            if(map.ContainsKey(c) && map[c] >= left){
                left = map[c] + 1;
                map[c] = i;
                continue;
            }

            map[c] = i;

            longest = Math.Max(longest, i - left + 1);
        }

        return longest;
    }
}
