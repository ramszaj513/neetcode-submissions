public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        HashSet<string> set = new HashSet<string>{"+","*","-","/"};

        foreach(string s in tokens){
            if(s.Length > 1 || char.IsDigit(s[0])){
                stack.Push(int.Parse(s));
            }
            else if(set.Contains(s)){
                int second = stack.Pop();
                int first = stack.Pop();

                int res = 0;
                if(s == "+"){ res = first + second;}
                if(s == "-"){ res = first - second;}
                if(s == "*"){ res = first * second;}
                if(s == "/"){ res = first / second;}

                stack.Push(res);
            }
        }

        return stack.Pop();
    }
}
