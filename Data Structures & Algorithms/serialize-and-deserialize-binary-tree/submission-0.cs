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

public class Codec {
    // to a preorder traversal
    // mark the null nodes too


    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        StringBuilder sb = new();

        void PreOrderDFS(TreeNode node){
            if(node == null) {
                sb.Append("#N");
                return;
            }
            else {sb.Append($"#{node.val}"); }

            PreOrderDFS(node.left);
            PreOrderDFS(node.right);
        }

        PreOrderDFS(root);
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        List<string> vals = data.Split('#').ToList();
        int id = 1;
        
        TreeNode constructPreorder(){
            string value = vals[id++];
            if(value == "N") return null;
            
            TreeNode newNode = new TreeNode(int.Parse(value));
            newNode.left = constructPreorder();
            newNode.right = constructPreorder();
            return newNode;
        }

        return constructPreorder();
    }
}
