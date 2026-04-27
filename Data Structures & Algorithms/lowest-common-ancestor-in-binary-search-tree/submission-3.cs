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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // we take the first node which is between or equal to one of the values
        // O(h) since in the worst case we just go the bottom of the tree
        TreeNode node = root;

        while(node != null){
            if(node.val < p.val && node.val < q.val){
                node = node.right;
            }
            else if(node.val > p.val && node.val > q.val){
                node = node.left;
            } 
            else{
                return node;
            }
        }
        
        return null; 
    }
}
