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
    public List<int> RightSideView(TreeNode root) {
        if(root == null) return new List<int>();

        List<int> res = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            int n = queue.Count;
            for(int i = 0; i < n; i++){
                TreeNode node = queue.Dequeue();
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
                if(i == n - 1){
                    res.Add(node.val);
                }
            }
        }

        return res;
    }
}
