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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head == null) return null;

        int length = 1;
        ListNode curr = head;

        while(curr.next != null){
            length++;
            curr = curr.next;
        }

        int i = 0;
        ListNode prev = null;
        curr = head;
        while(i < length - n){
            prev = curr;
            curr = curr.next;
            i++;  
        }

        if(prev == null){
            return curr.next;
        }
        else if(curr.next == null){
            prev.next = null;
        }
        else{
            prev.next = curr.next;
        }

        return head;
    }
}
