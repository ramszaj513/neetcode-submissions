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
    public bool IsBalanced(TreeNode root) {
        return DFS(root) == -1 ? false : true;
    }

    private int DFS(TreeNode node){
        if(node == null) return 0;

        int left = DFS(node.left);
        int right = DFS(node.right);

        if(left == -1 || right == -1){
            return -1;
        }

        if(Math.Abs(left - right) > 1){
            return -1;
        }

        return Math.Max(left,right) + 1;
    }
}
