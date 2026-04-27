/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    // we check the depth in node.left and right + 1 in each node and get the max
    // recursive
    public int DiameterOfBinaryTree(TreeNode root) {    
        int max = 0;
        GetHeight(root, ref max);
        return max;
    }

    private int GetHeight(TreeNode node, ref int max){
        if(node == null) return 0;
        int left = GetHeight(node.left, ref max);
        int right = GetHeight(node.right, ref max);
        max = Math.Max(max, left + right);
        return Math.Max(left,right) + 1;
    }

    // iterative
    // this can also be done using an iterative DFS
    // but we need to add a Dictioary where we save depth and diamater for each node
    // since we dont want to calculate stuff over and over again
}
