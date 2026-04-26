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
    public bool HasCycle(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while(fast != null){
            fast = fast.next;
            if(fast == null) break;
            if(fast == slow) return true;
            fast = fast.next;
            if(fast == null) break;
            if(fast == slow) return true;
            slow = slow.next;
        }

        return false;
    }
}
