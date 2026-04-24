public class Solution {
    public int CharacterReplacement(string s, int k) {
        // AAABABB

        // I need to keep track of which letter is the most frquent

        // Iterate and keep the starting point
        // Save the current characters in a map (c,count)
        // How to get the current k required

        // After reaching the k limit update the left point
        Dictionary<char,int> map = new Dictionary<char,int>();
        int l = 0;
        int max = 0;
        int maxLength = 0;

        for(int i = 0; i < s.Length; i++){
            char c = s[i];

            if(!map.ContainsKey(c)){
                map[c] = 0;
            }
            map[c]++;

            max = Math.Max(max,map[c]);

            if((i - l + 1) - max > k){
                map[s[l]]--;
                l++;
            }

            maxLength = Math.Max(i - l + 1, maxLength);
        }

        return maxLength;
    }
}
