public class Solution {
    private static int[][] dirs = new int[][]{
        new int[]{0,1},new int[]{0,-1},new int[]{-1,0},new int[]{1,0}
    };

    public void Solve(char[][] board) {
        // a group is surrounded if it doesnt touch a wall
        // we need to traverse all if the groups starting from the edges, and mark them as visited
        // then we change everything to X unless it was visited

        HashSet<(int,int)> visited = new HashSet<(int,int)>();
        int rows = board.Length;
        int cols = board[0].Length;

        for(int c = 1; c < cols - 1; c++) {
            if(board[0][c] == 'O' && !visited.Contains((0, c))) {
                bfs(0, c, visited, board);
            }
            if(board[rows - 1][c] == 'O' && !visited.Contains((rows - 1, c))) {
                bfs(rows - 1, c, visited, board);
            }
        }

        for(int r = 0; r < rows; r++) {
            if(board[r][0] == 'O' && !visited.Contains((r, 0))) {
                bfs(r, 0, visited, board);
            }
            if(board[r][cols - 1] == 'O' && !visited.Contains((r, cols - 1))) {
                bfs(r, cols - 1, visited, board);
            }
        }

        for(int i = 1; i < board.Length - 1; i++){
            for(int j = 1; j < board[0].Length - 1; j++){
                if(!visited.Contains((i,j))){
                    board[i][j] = 'X';
                }
            }
        }
    }

    private void bfs(int sr, int sc, HashSet<(int,int)> visited, char[][] board){
        Queue<(int,int)> q = new Queue<(int,int)>();
        visited.Add((sr,sc));
        q.Enqueue((sr,sc));

        while(q.Count > 0){
            (var r, var c) = q.Dequeue();
            foreach(var dir in dirs){
                var nr = r + dir[0];
                var nc = c + dir[1];
                if(nr < board.Length && nr >= 0 && nc < board[0].Length && nc >= 0 && board[nr][nc] == 'O' && !visited.Contains((nr,nc))){
                    visited.Add((nr,nc));
                    q.Enqueue((nr,nc));
                }
            }
        }
    }
}
