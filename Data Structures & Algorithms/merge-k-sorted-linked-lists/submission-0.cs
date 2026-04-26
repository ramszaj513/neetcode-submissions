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

public class Solution{
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while (true) {
            ListNode minNode = null;
            int minIdx = -1;
            int minVal = int.MaxValue;

            for (int i = 0; i < lists.Length; i++) {
                if (lists[i] != null && lists[i].val < minVal) {
                    minVal = lists[i].val;
                    minNode = lists[i];
                    minIdx = i;
                }
            }

            if (minIdx == -1) break;

            tail.next = lists[minIdx];
            tail = tail.next;
            lists[minIdx] = lists[minIdx].next;
        }
        return dummy.next;
    }
}

