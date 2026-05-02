public class Solution {
    List<List<string>> res = new();
    HashSet<int> cols = new();
    HashSet<int> posDiag = new();
    HashSet<int> negDiag = new();

    public List<List<string>> SolveNQueens(int n) {
        Dfs(0, n, new List<int>());
        return res;
    }

    private void Dfs(int r, int n, List<int> current) {
        if (r == n) {
            res.Add(BuildBoard(current, n));
            return;
        }

        for (int c = 0; c < n; c++) {
            if (cols.Contains(c) || posDiag.Contains(r + c) || negDiag.Contains(r - c)) {
                continue;
            }

            cols.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            current.Add(c);

            Dfs(r + 1, n, current);

            current.RemoveAt(current.Count - 1);
            cols.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
        }
    }

    private List<string> BuildBoard(List<int> current, int n) {
        List<string> board = new List<string>();
        foreach (int col in current) {
            char[] row = new char[n];
            Array.Fill(row, '.');
            row[col] = 'Q';
            board.Add(new string(row));
        }
        return board;
    }
}