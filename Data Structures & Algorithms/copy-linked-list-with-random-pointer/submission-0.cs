/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if(head == null) return null;

        Dictionary<Node,Node> map = new Dictionary<Node,Node>();

        Node headCopy = new Node(head.val);
        map[head] = headCopy;
        
        Node curr = head.next;
        Node currCopy = headCopy;
 
        // Copy the list without the random pointers and save the equivalents to a hashmap
        // 
        while(curr != null){ 
            Node copy = new Node(curr.val);
            currCopy.next = copy;
            currCopy = copy;            
            map[curr] = copy;
            curr = curr.next;
        }

        curr = head;
        currCopy = headCopy;
        while(curr != null){
            currCopy.random = (curr.random == null ? null : map[curr.random]);
            currCopy = currCopy.next;
            curr = curr.next;
        }

        return headCopy;
    }
}
