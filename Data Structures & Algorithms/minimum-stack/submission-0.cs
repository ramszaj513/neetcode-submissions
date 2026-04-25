public class MinStack {
    // We can do this using 2 stack
    // In the first one we save values and 
    // in the second one track history of the min element
  
    Stack<int> stack = new Stack<int>();
    Stack<int> min = new Stack<int>();

    public MinStack() {}
    
    public void Push(int val) {
        stack.Push(val);

        if(min.Count == 0){
            min.Push(val);
        }
        else{
            min.Push(Math.Min(min.Peek(),val));
        }
    }
    
    public void Pop() {
        stack.Pop();
        min.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return min.Peek();
    }
}
