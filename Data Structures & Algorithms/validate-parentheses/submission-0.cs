public class Solution {
    public bool IsValid(string s) {
        // let's create a stack
        // when we get the open parenthesis we push them onto the stack
        // when we got close we pop the stack and check  if they are matching

        Stack<char> stack = new Stack<char>();
        HashSet<char> open = new HashSet<char>{'(','[','{'};

        foreach(char c in s){
            if(open.Contains(c)){
                stack.Push(c);
            }
            else{
                if(stack.Count == 0) return false;
                char poped = stack.Pop();

                if (c == ')' && poped != '(') return false;
                if (c == ']' && poped != '[') return false;
                if (c == '}' && poped != '{') return false;
            }
        }

        return stack.Count == 0;
    }
}
