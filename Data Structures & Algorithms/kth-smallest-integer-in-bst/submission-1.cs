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
    // public int KthSmallest(TreeNode root, int k) {
    //     // traverse the tree in the right order and track the current position

    //     Stack<TreeNode> stack = new Stack<TreeNode>();
    //     TreeNode curr = root;

    //     while(stack.Count > 0 || curr != null){
    //         while (curr != null){
    //             stack.Push(curr);
    //             curr = curr.left;
    //         }

    //         curr = stack.Pop();
    //         k--;
    //         if(k == 0){
    //             return curr.val;
    //         }
    //         curr = curr.right;
    //     }

    //     return -1;
    // }

    // implementation without the stack (Morris traversal)
    public int KthSmallest(TreeNode root, int k) {
        // traverse the tree in the right order and track the current position
        
        TreeNode curr = root;

        while(curr != null){
            if(curr.left == null){
                if(--k == 0){ return curr.val; }

                // this is the important step (we go to the right subtree and eventually will 
                // come back to the top since its looped)
                curr = curr.right;
            }
            else{
                // find the the most right value (the largest number of left subtree)
                TreeNode prev = curr.left;
                while (prev.right != null && prev.right != curr) {
                    prev = prev.right;
                }

                // (we got null) we didnt list this subtree yet 
                // (we add a link to return and move to the subtree)
                if (prev.right == null) {
                    prev.right = curr;
                    curr = curr.left;
                }

                // (we got curr that means we ended the first tree and now are in the root (prev.right))
                // so we delete the link and start visiting the right subtree
                else {
                    prev.right = null;
                    if(--k == 0){ return curr.val; }
                    curr = curr.right;
                }
            }
        }

        return -1;
    }
}
