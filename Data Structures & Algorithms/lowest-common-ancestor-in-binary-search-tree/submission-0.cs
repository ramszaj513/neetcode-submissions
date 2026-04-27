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
        // find the nodes p and q
        // if we do recursion which checks left and right we can stop in the first node when left and right equals true

        // we can also to binary search to find both nodes and save the paths
        // then just take the first point where thay meet O(n)
        TreeNode node = root;

        while(true){
            if(node.val < p.val && node.val < q.val){
                node = node.right;
            }
            else if(node.val > p.val && node.val > q.val){
                node = node.left;
            }
            else if((node.val < p.val && node.val > q.val) || (node.val > p.val && node.val < q.val) || node.val == p.val || node.val == q.val){
                return node;
            }
        }
        
        return null;
    }
}
