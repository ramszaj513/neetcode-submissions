public class Solution {
    List<string> res = new List<string>();
    List<char>[] mapping = new List<char>[10];

    public List<string> LetterCombinations(string digits) {
        // 2-9
        // O(3^n) where n is the Length of digits
        // presave the mapping
        // or map it dynamicly

        if(digits.Length == 0) return new List<string>();

        for(int i = 0; i < 7; i++){
            mapping[i] = new List<char>();
            for(int j = 0; j < 3; j++){
                mapping[i].Add((char)('a' + (i - 2)*3 + j));
            }
        } 
        mapping[7] = new List<char>{'p','q','r','s'};
        mapping[8] = new List<char>{'t','u','v'};
        mapping[9] = new List<char>{'w','x','y','z'};

        dfs(0, digits, new List<char>());
        return res;
    }

    private void dfs(int indx, string digits, List<char> current){
        if(indx >= digits.Length){
            res.Add(new string(current.ToArray()));
            return;
        }

        int digit = digits[indx] - '0';
        foreach(var num in mapping[digit]){
            current.Add(num);
            dfs(indx + 1, digits, current);
            current.RemoveAt(current.Count - 1);
        }
    }
}
