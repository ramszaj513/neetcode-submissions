public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var set = new HashSet<int>();

        for(int i = 0; i < 9; i++) {
            set.Clear();
            for(int j = 0; j < 9; j++) {
                if(board[i][j] == '.') continue;
                int val = board[i][j] - '0';
                if(set.Contains(val)) return false;
                set.Add(val);
            }
        }

        for(int i = 0; i < 9; i++) {
            set.Clear();
            for(int j = 0; j < 9; j++) {
                if(board[j][i] == '.') continue;
                int val = board[j][i] - '0';
                if(set.Contains(val)) return false;
                set.Add(val);
            }
        }

        for(int k = 0; k < 3; k++) { 
            for(int m = 0; m < 3; m++) {
                set.Clear();
                for(int i = k * 3; i < k * 3 + 3; i++) {
                    for(int j = m * 3; j < m * 3 + 3; j++) {
                        if(board[i][j] == '.') continue;
                        int val = board[i][j] - '0';
                        if(set.Contains(val)) return false;
                        set.Add(val);
                    }
                }
            }
        }

        return true;
    }
}
