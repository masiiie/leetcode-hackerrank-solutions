// https://leetcode.com/problems/merge-two-sorted-lists/

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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null) return list2;
        if(list2 == null) return list1;
        ListNode solution = new ListNode(0);
        ListNode actual = solution;

        while(list1 != null || list2 != null){
            if(list1 == null){
                actual.val = list2.val;
                actual.next = list2.next;
                return solution;
            } 
            else if(list2 == null){
                actual.val = list1.val;
                actual.next = list1.next;
                return solution;
            }
            else if(list1.val < list2.val){
                actual.val = list1.val;
                list1 = list1.next;
            }
            else if(list2.val <= list1.val){
                actual.val = list2.val;
                list2 = list2.next;
            }
            actual.next = new ListNode(0);
            actual = actual.next;
        }  

        return solution;
    }
}