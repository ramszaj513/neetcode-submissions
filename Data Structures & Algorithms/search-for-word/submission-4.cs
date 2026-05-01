public class Solution {
    public bool Exist(char[][] board, string word) {
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                if(board[i][j] == word[0]){
                    if(Backtrack(board, word, i, j, 0)) return true;
                }
            }
        }
        return false;
    }

    private bool Backtrack(char[][] board, string word, int r, int c, int index) {
        if (index == word.Length) return true;
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] != word[index]) {
            return false;
        }

        char temp = board[r][c];
        board[r][c] = '#';

        bool found = Backtrack(board, word, r + 1, c, index + 1) ||
                     Backtrack(board, word, r - 1, c, index + 1) ||
                     Backtrack(board, word, r, c + 1, index + 1) ||
                     Backtrack(board, word, r, c - 1, index + 1);

        board[r][c] = temp;

        return found;
    }
}
