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
    int best = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        // we perform a recursive DFS which return in each node the best where node is the heighest
        // and keep a global maxpath sum value

        DFS(root);
        return best;
    }

    private int DFS(TreeNode node){
        if(node == null) return 0;

        int leftPath = DFS(node.left);
        int rightPath = DFS(node.right);

        int leftSum = leftPath + node.val;
        int rightSum = rightPath + node.val;
        int bothSums = leftPath + rightPath + node.val;

        int currentBest = Math.Max(node.val, Math.Max(bothSums, Math.Max(leftSum,rightSum)));
        best = Math.Max(best, currentBest);
        
        return Math.Max(node.val, Math.Max(leftPath + node.val, rightPath + node.val));
    }
}
