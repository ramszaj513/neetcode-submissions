public class Solution {
    List<string> res = new List<string>();

    public List<string> LetterCombinations(string digits) {
        // 2-9
        // O(3^n) where n is the Length of digits
        // presave the mapping
        // or map it dynamicly

        if(digits.Length == 0) return new List<string>();
        dfs(0, digits, new List<char>());
        return res;
    }

    private void dfs(int indx, string digits, List<char> current){
        if(indx >= digits.Length){
            res.Add(new string(current.ToArray()));
            return;
        }

        int digit = digits[indx] - '0';
        if(digit == 7){
            for(int i = 0; i < 4; i++){
                current.Add((char)('p' + i));
                dfs(indx + 1, digits, current);
                current.RemoveAt(current.Count - 1);
            }
        }
        else if(digit == 8){
            for(int i = 0; i < 3; i++){
                current.Add((char)('t' + i));
                dfs(indx + 1, digits, current);
                current.RemoveAt(current.Count - 1);
            } 
        }
        else if(digit == 9){
            for(int i = 0; i < 4; i++){
                current.Add((char)('w' + i));
                dfs(indx + 1, digits, current);
                current.RemoveAt(current.Count - 1);
            } 
        }
        else{
            for(int i = 0; i < 3; i++){
                current.Add((char)('a' + (digit - 2)*3 + i));
                dfs(indx + 1, digits, current);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
