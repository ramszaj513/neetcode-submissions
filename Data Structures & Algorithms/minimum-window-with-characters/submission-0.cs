public class Solution {
    public string MinWindow(string s, string t) {
        // map to count letters in t
        // save the starting points
        // we only care about the letters wgucg exists in the xyz array

        // naive approach:
        // each substring i and i + j

        // letterCounts
        // windowCount
        // start
        // matches
        // new letter:
        // exists in t -> update the matches (if its too much we check if we can delete letters from behind)
        //                if the matches  are equal the length of t save the length of the window
        // doesnt exist in t -> update the length of the window

        int n = s.Length;

        var letterCount = new Dictionary<char,int>();
        foreach(char c in t){   
            if(!letterCount.ContainsKey(c)){
                letterCount[c] = 1;
            }
            else{
                letterCount[c]++;
            }
        }

        int start = 0;
        int need = letterCount.Count;
        int have = 0;
        var windowCount = new Dictionary<char,int>();
        int best = int.MaxValue;
        int bestStart = 0;

        for(int i = start; i < n; i++){
            char c = s[i];
            if(!windowCount.ContainsKey(c)){
                windowCount[c] = 1;
            } else{
                windowCount[c]++;
            }

            if(letterCount.ContainsKey(c) && windowCount[c] == letterCount[c]){
                have++;
            }

            while(have == need){
                if((i - start + 1) < best){
                    best = i - start + 1;
                    bestStart = start;
                }

                char leftChar = s[start];
                windowCount[leftChar]--;

                if(letterCount.ContainsKey(leftChar) && windowCount[leftChar] < letterCount[leftChar]) {
                    have--;
                }
                start++;
            }
        }
        
        if(best != int.MaxValue){
            return s.Substring(bestStart, best);
        }
        else{
            return "";
        }
    }
}
