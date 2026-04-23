public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // iterate through the string array
        // calculate the count of each letter in a string
        // add the calculated array of counts in a hashMap

        var map = new Dictionary<string, List<string>>();

        for(int i = 0; i < strs.Length; i++){
            int[] counts = new int[26];

            for(int j = 0; j < strs[i].Length; j++){
                counts[strs[i][j] - 'a']++;
            }

            string key = string.Join("#", counts);

            if(!map.ContainsKey(key)){
                map[key] = new List<string>();
            }
            map[key].Add(strs[i]);
        }

        return map.Values.ToList();
    }
}
