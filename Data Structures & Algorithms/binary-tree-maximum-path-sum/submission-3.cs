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
    public int MaxPathSum(TreeNode root) {
        // the max path containing a node 
        // is equal to the 
        // max(node.left.pathleft, node.left.pathright) + 
        // + max(node.right.pathright, node.right.pathright)

        // we perform a recursive DFS which return in each node the best pathwhich starts from it
        // and keep a global maxpath sum value

        int bestSum = int.MinValue;
        DFS(root, ref bestSum);
        return bestSum;
    }

    private int DFS(TreeNode node, ref int bestSum){
        if(node == null) return 0;

        int leftPath = DFS(node.left, ref bestSum);
        int rightPath = DFS(node.right, ref bestSum);

        int leftSum = leftPath + node.val;
        int rightSum = rightPath + node.val;
        int bothSums = leftPath + rightPath + node.val;

        int currentBest = Math.Max(node.val, Math.Max(bothSums, Math.Max(leftSum,rightSum)));
        bestSum = Math.Max(bestSum, currentBest);
        
        return Math.Max(node.val, Math.Max(leftPath + node.val, rightPath + node.val));
    }
}
