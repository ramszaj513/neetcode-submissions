public class Solution {
    List<List<string>> res = new();

    public List<List<string>> Partition(string s) {
        dfs(new List<int>(), 0, 0, s);
        return res;
    }

    private void dfs(List<int> divisions, int i, int j, string s){
        if (i == s.Length) {
            List<string> currentPartition = new List<string>();
            int lastIndex = 0;
            foreach (int cut in divisions) {
                currentPartition.Add(s.Substring(lastIndex, cut - lastIndex + 1));
                lastIndex = cut + 1;
            }
            res.Add(currentPartition);
            return;
        }

        if (j >= s.Length) return;

        dfs(divisions, i, j + 1, s);


        bool isPalindrome = true;
        for(int d = 0; d <= (j-i)/2; d++){
            if(s[i + d] != s[j - d]){
                isPalindrome = false;
                break;
            }
        }

        if(isPalindrome){
            divisions.Add(j);
            dfs(divisions, j + 1, j + 1, s);
            divisions.RemoveAt(divisions.Count - 1);
        }
    }
}
