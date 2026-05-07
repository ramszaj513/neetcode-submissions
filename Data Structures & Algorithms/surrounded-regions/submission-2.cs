public class Solution {
    private static int[][] dirs = new int[][]{
        new int[]{0,1},new int[]{0,-1},new int[]{-1,0},new int[]{1,0}
    };

    public void Solve(char[][] board) {
        // a group is surrounded if it doesnt touch a wall
        // we need to traverse all if the groups starting from the edges, and mark them as visited
        // then we change everything to X unless it was visited

        HashSet<(int,int)> visited = new HashSet<(int,int)>();
        bfs(visited,board);

        for(int i = 1; i < board.Length - 1; i++){
            for(int j = 1; j < board[0].Length - 1; j++){
                if(!visited.Contains((i,j))){
                    board[i][j] = 'X';
                }
            }
        }
    }

    private void bfs(HashSet<(int,int)> visited, char[][] board){
        Queue<(int,int)> q = new Queue<(int,int)>();
        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                if ((r == 0 || r == board.Length - 1 ||
                    c == 0 || c == board[0].Length - 1) &&
                    board[r][c] == 'O') {
                    q.Enqueue((r,c));
                }
            }
        }

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
