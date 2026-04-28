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
    public int GoodNodes(TreeNode root) {
        return DFS(root, int.MinValue);
    }

    private int DFS(TreeNode node, int max){
        if(node == null) return 0;
        if(node.val > max){
            max = node.val;
        }

        int countLeft = DFS(node.left, max);
        int countRight = DFS(node.right, max);

        return countLeft + countRight + (node.val == max ? 1 : 0);
    }
}
