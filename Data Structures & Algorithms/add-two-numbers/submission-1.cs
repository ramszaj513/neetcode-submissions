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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // do a classic addition
        // O(n) O(1) solution

        // we can also just recreate the number is int/long, add them and recreate the list
        // they are too long so that is a bad idea

        ListNode newHead = null;
        ListNode prev = null;
        int additional = 0;

        while(l1 != null || l2 != null || additional != 0){
            int sum = additional;
            if(l1 != null) sum += l1.val;
            if(l2 != null) sum += l2.val;

            if(sum > 9){
                additional = 1;
                sum = sum % 10;
            } else{
                additional = 0;
            }

            ListNode newNode = new ListNode(sum, null);
            if(prev == null){
                newHead = newNode;
            }
            else{
                prev.next = newNode; 
            }
            
            prev = newNode;

            if(l1 != null) l1 = l1.next;
            if(l2 != null) l2 = l2.next;
        }

        // if(additional != 0){
        //     prev.next = new ListNode(additional,null);
        // }

        return newHead;
    }
}
