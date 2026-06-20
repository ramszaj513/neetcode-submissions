public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        // hand[i] - value written on the ith card
        // rearrange the cards so that in each group there is 
        // a sequence with 1 diff and size of groupSize

        // we can sort the array
        // we know that we have to start a group with min value
        // then we can delete it and again start with min value

        // we dont have to sort the array
        // we can create a hash map to keep the count of each value
        // we go to the min value (then delete each rising number until we reach the groupcount)
        // then we check if there is another min
        // if not we go higher
        
        // O(n), O(n)
        if(hand.Length % groupSize != 0) return false;

        int[] map = new int[hand.Max() + 1]; 
        for(int i = 0; i < hand.Length; i++){
            map[hand[i]]++;
        }

        int count = 0;

        for(int i = 0; i < map.Length; i++){
            if(count == hand.Length) break;

            while(map[i] > 0){
                for(int j = i; j < i + groupSize; j++){
                    if(j >= map.Length || map[j] == 0) return false; 
                    
                    map[j]--;
                    count++;
                }
            }
        }

        return true;
    }
}
