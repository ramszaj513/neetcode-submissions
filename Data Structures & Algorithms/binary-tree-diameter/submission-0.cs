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
        if(root == null) return 0;
        int max = 0;

        int GetHeight(TreeNode node){
            if(node == null) return 0;
            int left = GetHeight(node.left);
            int right = GetHeight(node.right);
            max = Math.Max(max, left + right);
            return Math.Max(left,right) + 1;
        }

        GetHeight(root);
        return max;
    }

    // iterative
    // public int DiameterOfBinaryTree(TreeNode root) {    
    //     if(root == null) return null;
    //     int max = 0;

    //     Stack<(TreeNode,int)> stack = new Stack<(TreeNode,int)>();
    //     stack.Push((root,1)){
    //         (var node, var depth) = stack.Pop();
            
    //         if(node.left != null) stack.Push((node.left, depth + 1));
    //         if(node.right != null) stack.Push((node.right, depth + 1));

    //         max = Math.Max()
    //     }
    // }
}
