public class Solution {
    List<string> res = new();

    public List<string> GenerateParenthesis(int n) {
        Backtrack(0, 0,new List<char>(), 2*n);
        return res;
    }

    private void Backtrack(int i, int open, List<char> current, int n){
        if(current.Count == n){
            res.Add(new string(current.ToArray()));
            return;
        }

        if(open > 0){
            current.Add(')');
            Backtrack(i+1, open - 1, current, n);
            current.RemoveAt(current.Count - 1);
        }

        if(n - i > open){
            current.Add('(');
            Backtrack(i+1, open + 1, current, n);
            current.RemoveAt(current.Count - 1);
        }
    }
}
