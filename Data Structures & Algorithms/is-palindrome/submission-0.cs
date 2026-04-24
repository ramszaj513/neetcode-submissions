public class Solution {
    public bool IsPalindrome(string s) {
        // convert to a string with only alpahumerics and lowercase chars
        // check pairs

        string cleanString = new String(s.Where(c => char.IsLetterOrDigit(c)).ToArray());
        cleanString = cleanString.ToLower();

        for(int i = 0; i < cleanString.Length/2; i++){
            if(cleanString[i] != cleanString[cleanString.Length - 1 - i]){
                return false;
            }
        }

        return true;
    }
}
