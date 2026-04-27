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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> levels = new List<List<int>>();
        if(root == null) return levels;

        Queue<(TreeNode,int)> queue = new Queue<(TreeNode,int)>();
        queue.Enqueue((root,0));
        int lastDistance = -1;

        while(queue.Count > 0){
            (var node, var distance) = queue.Dequeue();
            
            if(lastDistance != distance) {
                levels.Add(new List<int>{node.val});
                lastDistance = distance;
            }
            else{
                levels[lastDistance].Add(node.val);
            }

            if(node.left != null) queue.Enqueue((node.left, lastDistance + 1));
            if(node.right != null) queue.Enqueue((node.right, lastDistance + 1));
        }

        return levels;
    }
}
