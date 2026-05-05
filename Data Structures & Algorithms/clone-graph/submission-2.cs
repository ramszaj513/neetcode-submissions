/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        // we only need an array of size n where we add and store nodes
        // we can also do it using a HashMap to to initialize an array we n values
        if(node == null) return null;

        Dictionary<Node, Node> map = new Dictionary<Node,Node>();
        Stack<Node> s = new Stack<Node>();
        s.Push(node);
        map[node] = new Node(node.val);

        while(s.Count > 0){
            Node curr = s.Pop();
            foreach(var neighbor in curr.neighbors){
                if(!map.ContainsKey(neighbor)){
                    map[neighbor] = new Node(neighbor.val);
                    s.Push(neighbor);
                }
                map[curr].neighbors.Add(map[neighbor]);
            }
        }

        return map[node];
    }
}
