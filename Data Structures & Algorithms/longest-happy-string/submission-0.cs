public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        // happy -> contains only letter a b c
        // does not contain aaa bbb ccc
        // at most a occurences of a
        // at most b occurences of b
        // at most c occurences of c

        // we want to return the longest possible happy string
        // using the given letters

        // okay so the first thing that pops into my mind
        // is looking at this as divisions
        // so given that we have a lot of letter a
        // we want to place b in such a way that a is divided correctly
        // in case of two letters the basic idea would be to do something like this till we are able
        // aabaabaabaab
        // when there are 3 letters there comes an issue
        
        // we wont to insert the cs in such a way to also allow for divisioning
        // lets take the letter which is the most frequent
        // and then the second most frequent letter
        // we add them as a sequence of aabaabaab
        // until there is no b left, in the case of a left a
        // we fill with c later
        // in the case of be left we fill the bb fields
        // the we add c where we wont ewentually

        // we always want to fill the most frequent values with
        // the values that are not the most frequent
        
        string res = "";
        PriorityQueue<(int count, char ch),int> maxHeap = new();

        void AddToHeap(int count, char ch){
            if(count > 0){
                maxHeap.Enqueue((count,ch),-count);
            }
        }

        AddToHeap(a,'a');
        AddToHeap(b,'b');
        AddToHeap(c,'c');

        while(maxHeap.Count > 0){
            var (count1, ch1) = maxHeap.Dequeue();

            if(res.Length >= 2 && res[^1] == ch1 && res[^2] == ch1){
                if(maxHeap.Count == 0) break; 
                var (count2, ch2) = maxHeap.Dequeue();
                res += ch2;
                count2--;
                AddToHeap(count2,ch2);
                AddToHeap(count1, ch1);
            } else {
                res += ch1;
                count1--;
                AddToHeap(count1, ch1);
            }
        }

        return res;
    }
}