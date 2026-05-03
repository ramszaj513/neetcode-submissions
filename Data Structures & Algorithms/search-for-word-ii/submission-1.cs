public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public string word = null;
    }
    
    private TrieNode root = new TrieNode();
    private List<string> res = new List<string>();
    
    public List<string> FindWords(char[][] board, string[] words) {
        foreach(string word in words) {
            TrieNode curr = root;
            foreach(char c in word) {
                if(!curr.children.ContainsKey(c)) {
                    curr.children[c] = new TrieNode();
                }
                curr = curr.children[c];
            }
            curr.word = word;
        }

        for(int r = 0; r < board.Length; r++) {
            for(int c = 0; c < board[0].Length; c++) {
                dfs(r, c, root, board);
            }
        }
        return res;
    }

    public void dfs(int r, int c, TrieNode node, char[][] board) {
        if(r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] == '#') return;

        char letter = board[r][c];

        if(!node.children.ContainsKey(letter)) return;

        TrieNode nextNode = node.children[letter];

        if(nextNode.word != null) {
            res.Add(nextNode.word);
            nextNode.word = null;
        }

        board[r][c] = '#';
        dfs(r + 1, c, nextNode, board);
        dfs(r - 1, c, nextNode, board);
        dfs(r, c + 1, nextNode, board);
        dfs(r, c - 1, nextNode, board);
        board[r][c] = letter;
    }
}