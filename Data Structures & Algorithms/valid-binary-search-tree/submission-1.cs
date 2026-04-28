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
    public bool IsValidBST(TreeNode root) {
        return isValidDFS(root.left, int.MinValue, root.val) && isValidDFS(root.right, root.val, int.MaxValue);
    }

    public bool isValidDFS(TreeNode node, int min, int max){
        if(node == null) return true;
        if(node.val <= min) return false;
        if(node.val >= max) return false;

        return isValidDFS(node.left, min, node.val) && isValidDFS(node.right, node.val, max);
    }
}
