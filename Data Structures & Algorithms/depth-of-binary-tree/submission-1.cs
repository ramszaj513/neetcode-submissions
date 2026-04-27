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
    // Space complexity here is O(h) for the balanced tree and O(n) for the degenerated !!!
    // Because in tree balanced tree we keep only h open function calls on the stack (until we reach the leaf and come back)
    // public int MaxDepth(TreeNode root) {
    //     if(root == null) return 0;
    //     return Math.Max(MaxDepth(root.left),MaxDepth(root.right)) + 1;
    // }

    // O(n) time and O(n) space
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;

        Stack<(TreeNode,int)> stack = new Stack<(TreeNode,int)>();
        stack.Push((root,1));
        int max = 1;

        while(stack.Count > 0){
            (var node, var depth) = stack.Pop();
            max = Math.Max(max,depth);
            if(node.right != null) stack.Push((node.right, depth + 1));
            if(node.left != null) stack.Push((node.left, depth + 1));
        }

        return max;
    }
}
