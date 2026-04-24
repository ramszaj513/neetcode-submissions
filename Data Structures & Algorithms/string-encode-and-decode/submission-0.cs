public class Solution {

    public string Encode(IList<string> strs) {
        // Example: #2fd#4fdsf#5fsdgh
        StringBuilder sb = new StringBuilder();

        foreach(string s in strs){
            int n = s.Length;
            sb.Append(Convert.ToChar(n));
            sb.Append('#');
            sb.Append(s);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s) {
        List<string> strs = new List<string>();
        StringBuilder sb = new StringBuilder();

        int i = 0;

        while (i < s.Length) {
            int length = (int)s[i];
            i += 2; 
            strs.Add(s.Substring(i, length));
            i += length;
        }

        return strs;
   }
}
