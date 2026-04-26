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
        if(lists.Length == 0) return null;
        if(lists.Length == 1) return lists[0];

        for(int i = 1; i < lists.Length; i++){
            lists[i] = MergeTwoLists(lists[i-1], lists[i]);
        }

        return lists[lists.Length - 1];

        // ListNode dummy = new ListNode(0);
        // ListNode tail = dummy;

        // while (true) {
        //     ListNode minNode = null;
        //     int minIdx = -1;
        //     int minVal = int.MaxValue;

        //     for (int i = 0; i < lists.Length; i++) {
        //         if (lists[i] != null && lists[i].val < minVal) {
        //             minVal = lists[i].val;
        //             minNode = lists[i];
        //             minIdx = i;
        //         }
        //     }

        //     if (minIdx == -1) break;

        //     tail.next = lists[minIdx];
        //     tail = tail.next;
        //     lists[minIdx] = lists[minIdx].next;
        // }
        // return dummy.next;
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2){
        if(l1 == null && l2 == null) return null;

        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while(l1 != null && l2 != null){
            if (l1.val <= l2.val) {
                tail.next = l1;
                l1 = l1.next;
            } else {
                tail.next = l2;
                l2 = l2.next;
            }

            tail = tail.next;
        }

        tail.next = (l1 == null) ? l2 : l1;
        return dummy.next;
    }
}

