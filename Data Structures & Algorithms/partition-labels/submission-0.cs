public class Solution {
    public List<int> PartitionLabels(string s) {
        // we need to divide the string as much as possible,
        // while making sure that each letter is in only one division
        
        // when we consider only one letter its easy
        // we have to divide starting from the first occurence to the last
        // the problem is that iterating letter by letter is not really optimal
        // we can create a dictionary with list of indexes of each letter occurance
        // then go trough the dictionary and create division
        // if the division are coming on each other we need to combine them
        
        // O(n) -> O(n) ->

        // we can count each letters occurence within the word
        // then go from left to right that way we know if the division is right
        // without having to check forward 

        // how do I truck which letters are in the current division
        // I can create a hashSet<>
        // each time a new letter comes in I add it there
        // if it was there already I decrease its count
        // if its count is 0 i decrease the remaining count

        Dictionary<char,int> count = new Dictionary<char,int>();
        for(int i = 0; i < s.Length; i++){
            if(!count.ContainsKey(s[i])){
                count[s[i]] = 1;
            } else{
                count[s[i]]++;
            }
        } 

        int length = 0;
        int left = 0;
        HashSet<char> current = new HashSet<char>();
        List<int> divisions = new List<int>();

        foreach(var c in s){
            length++;
            if(current.Contains(c)){
                count[c]--;
                if(count[c] == 0){
                    left--;
                }
            } else{
                current.Add(c);
                count[c]--;
                if(count[c] != 0){
                    left++;
                }
            }

            if(left == 0){
                divisions.Add(length);
                length = 0;
                current = new HashSet<char>();
            }
        }

        return divisions;
    }
}
