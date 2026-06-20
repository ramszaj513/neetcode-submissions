public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        // 2D array
        // triplets[i] = [ai, bi, ci]
        // target = [x,y,z] - the triplet we want to obtain
        // triplets[i] and triplets[j] -> [max(ai,aj), max(bi,bj), max(ci,cj)]

        // [[1,2,3],[7,1,1]] target 7,2,3
        // we have to start with a triplet which contains the maximum value
        // then we can use triplets which are smaller than that
        // we only need max two operatins to obtain the target
        // we need to find 1 or 2 or 3 triplets which dont cancel each other out
        // (each value has to max in that combination the order doesnt matter)

        // when finding the first triplet we search for something which has the correct value in one field
        // and the other shuold be as small as possible (if they are bigger than target we dont even consider them)

        // if it has two correct values we dont care about it
        // we go for the next triplet with value which is bigger than

        // basicly we need to find triplets which have following properties:
        // 1. Matches the current value field
        // 2. Both other values are smaller than target
        // if we can find one triplet like that for each target it possible to combine them and get the solution

        bool cond1 = false;
        bool cond2 = false;
        bool cond3 = false;
        for(int i = 0; i < triplets.Length; i++){
            var triplet = triplets[i];
            if(triplet[0] == target[0] && triplet[1] <= target[1] && triplet[2] <= target[2]) cond1 = true;
            if(triplet[1] == target[1] && triplet[0] <= target[0] && triplet[2] <= target[2]) cond2 = true;
            if(triplet[2] == target[2] && triplet[1] <= target[1] && triplet[0] <= target[0]) cond3 = true;
        }
        
        return cond1 && cond2 && cond3;
    }
}
