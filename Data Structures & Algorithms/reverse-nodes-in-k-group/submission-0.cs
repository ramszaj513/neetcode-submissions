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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode curr = head;
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;

        while(true){
            ListNode last = GetKth(curr, k);
            if(last == null){ break; }

            ListNode start = curr;
            ListNode lastNext = last.next;
            prev.next = last;
            prev = lastNext;

            // reverse the list
            for(int i = 0; i < k; i++){
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            prev = start;
            curr = lastNext;
        }

        return dummy.next;
    }

    private ListNode GetKth(ListNode head, int k){
        ListNode curr = head;
        int i = 1;
        while(curr != null && i < k){
            curr = curr.next;
            i++;
        }
        return curr;
    }

    // ReverseL and returns the tail
    // private ListNode ReverseK(ListNode head, int k){
    //     ListNode curr = head;
    //     ListNode prev = null;

    //     for(int i = 0; i < n; i++){
    //         if(curr == null){
    //             return prev;
    //         }

    //         ListNode tmp = curr.next;
    //         curr.next = prev;
    //         prev = curr;
    //         curr = tmp;
    //     }

    //     return prev; // current head
    // }
}
