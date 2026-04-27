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
        if(root == null) return true;
        bool res = true;
        DFS(root, ref res);
        return res;
    }

    private int DFS(TreeNode node, ref bool isBalanced){
        if(node == null) return 0;

        int left = DFS(node.left, ref isBalanced);
        int right = DFS(node.right, ref isBalanced);

        if(Math.Abs(left - right) > 1){
            isBalanced = false;
        }

        return Math.Max(left,right) + 1;
    }
}
