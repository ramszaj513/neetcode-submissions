public class Solution {
    public bool CheckValidString(string s) {
        // I keep a stack for the parenthesis
        // if there is a * sign i should 

        // keep two stacks
        // one for open parenthesis
        // one for stars

        // if there is a closing parenthesis and the open stack i empty
        // we use a star, if both arent there then it is impossible
        // if the open parenthesis stack is not empty at the end then its also not possible

        Stack<int> parenthesis = new Stack<int>();
        Stack<int> stars = new Stack<int>();

        for(int i = 0; i < s.Length; i++){
            char c = s[i];
            switch(c){
                case '(':
                    parenthesis.Push(i);
                    break;
                case ')':
                    if(parenthesis.Count != 0){
                        parenthesis.Pop();
                    }
                    else if(stars.Count != 0){
                        stars.Pop();
                    }
                    else{
                        return false;
                    }
                    break;
                default:
                    stars.Push(i);
                    break;
            }
        }

        while(parenthesis.Count != 0){
            if(stars.Count == 0) return false;
            
            int ind1 = parenthesis.Pop();
            int ind2 = stars.Pop();
            if(ind1 > ind2) return false;
        }

        return true;
    }
}
