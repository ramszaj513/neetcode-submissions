public class Solution {
    public bool IsAnagram(string s, string t) {
        // Count number of each character in the strings
        // Then compare 
        // We can do it using a HashMap

        var charCountsS = new Dictionary<char, int>();

        foreach (var c in s){
            if(charCountsS.ContainsKey(c)){
                charCountsS[c]++;
            }
            else{
                charCountsS[c] = 1;
            }
        }

        foreach (var c in t){
            if(charCountsS.ContainsKey(c)){
                charCountsS[c]--;
            }
            else{
                return false;
            }
        }

        return charCountsS.Values.All(v => v == 0);        
    }
}
