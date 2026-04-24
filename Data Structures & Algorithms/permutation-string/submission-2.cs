public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n = s2.Length;
        int m = s1.Length;

        if(n < m) return false;

        // Save the count of each letter in a map
        Dictionary<char,int> map = new Dictionary<char,int>();
        foreach(char c in s1){
            if(!map.ContainsKey(c)){
                map[c] = 0;
            }
            map[c]++;
        }
        
        int matches = 0;

        Dictionary<char,int> windowMap = new Dictionary<char,int>();

        for(int i = 0; i < m; i++){
            char c = s2[i];

            if(!windowMap.ContainsKey(c)){
                windowMap[c] = 0;
            }
            windowMap[c]++;

            if(map.ContainsKey(c)){
                if(windowMap[c] > map[c]){
                    matches--;
                }
                else{
                    matches++;
                }
            }

            if(matches == m) return true;
        }

        int start = 0;

        for(int i = m; i < n; i++){
            char newC = s2[i];
            char oldC = s2[start];

            if(map.ContainsKey(oldC)){
                if(windowMap[oldC] <= map[oldC]){
                    matches--;
                }
                else{
                    matches++;
                }
            }

            windowMap[oldC]--;

            if(!windowMap.ContainsKey(newC)){
                windowMap[newC] = 0;
            }
            windowMap[newC]++;

            if(map.ContainsKey(newC)){
                if(windowMap[newC] > map[newC]){
                    matches--;
                }
                else{
                    matches++;
                }
            }

            start++;

            if(matches == m) return true;
        }

        return false;

    }
}
