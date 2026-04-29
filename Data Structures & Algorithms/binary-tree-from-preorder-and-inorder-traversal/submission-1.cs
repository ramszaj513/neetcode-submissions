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
    // public TreeNode BuildTree(int[] preorder, int[] inorder) {
    //     // save the indices of inorder elements in a hashmap
    //     var map = new Dictionary<int,int>();
    //     for(int i = 0; i < inorder.Length; i++){
    //         map[inorder[i]] = i;
    //     }

    //     // we track where we are in the preorder array
    //     int pre_idx = 0;

    //     // we go through the preorder array from left to right
    //     // we create a node and then pin to it the left subtree
    //     // to get the subtree we recursively call the function marking its beginning and end in the inorder array
    //     TreeNode DFS(int l, int r){
    //         if(l > r) return null;
    //         int root_val = preorder[pre_idx++];
    //         TreeNode root = new TreeNode(root_val);
    //         int mid = map[root_val];
    //         root.left = DFS(l, mid-1);
    //         root.right = DFS(mid+1, r);
    //         return root;
    //     }

    //     return DFS(0, preorder.Length - 1);
    // }


    // we can do this also without the hashmap
    // basicly instead of getting the index each time from the hashmap
    // we limit the subtree array in the inorder by the current root val
    // if we reach it we now we visited the whole subtree
    int preIdx = 0;
    int inIdx = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return Dfs(preorder, inorder, int.MaxValue);
    }

    private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {
        if (preIdx >= preorder.Length) return null;
        if (inorder[inIdx] == limit) {
            inIdx++;
            return null;
        }

        TreeNode root = new TreeNode(preorder[preIdx++]);
        root.left = Dfs(preorder, inorder, root.val);
        root.right = Dfs(preorder, inorder, limit);
        return root;
    }
}
