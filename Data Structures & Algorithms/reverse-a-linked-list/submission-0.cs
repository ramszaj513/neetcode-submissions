/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head == null) return null;

        ListNode current = head.next;
        ListNode prev = head;
        prev.next = null;

        while(current != null){
            ListNode next = current.next;
            current.next = prev;
            prev = current; 
            current = next;
        }

        return prev;
    }
}
