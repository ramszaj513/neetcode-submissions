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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null && subRoot != null) return false;
        if(IsSameTree(root,subRoot)) return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode p, TreeNode q) {
        if((p == null) != (q == null)) return false;
        if(p == null && q == null) return true;

        var stack = new Stack<(TreeNode, TreeNode)>();
        stack.Push((p,q));

        while(stack.Count > 0){
            (var node1, var node2) = stack.Pop();
            if(node1.val != node2.val){
                return false;
            }
            if((node1.left == null) != (node2.left == null)){
                return false;
            }
            if((node1.right == null) != (node2.right == null)){
                return false;
            }
            if(node1.left != null) stack.Push((node1.left,node2.left));
            if(node1.right != null) stack.Push((node1.right,node2.right));
        }

        return true;
    }
}
