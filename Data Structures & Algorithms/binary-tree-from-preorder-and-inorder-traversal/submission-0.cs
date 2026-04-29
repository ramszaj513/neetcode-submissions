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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // save the indices of inorder elements in a hashmap
        var map = new Dictionary<int,int>();
        for(int i = 0; i < inorder.Length; i++){
            map[inorder[i]] = i;
        }

        // we track where we are in the preorder array
        int pre_idx = 0;

        // we go through the preorder array from left to right
        // we create a node and then pin to it the left subtree
        // to get the subtree we recursively call the function marking its beginning and end in the inorder array
        TreeNode DFS(int l, int r){
            if(l > r) return null;
            int root_val = preorder[pre_idx++];
            TreeNode root = new TreeNode(root_val);
            int mid = map[root_val];
            root.left = DFS(l, mid-1);
            root.right = DFS(mid+1, r);
            return root;
        }

        return DFS(0, preorder.Length - 1);
    }

    
}
