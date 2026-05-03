public class Solution {
    private static readonly int[][] directions = new int[][]{
        new int[] {1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1}
    };

    public int NumIslands(char[][] grid) {
        int count = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){ 
                if(grid[i][j] == '1'){
                    dfs(i,j,grid);
                    count++;
                }
            }
        }
        return count;
    }

    // public void dfs(int r, int c, char[][] grid){
    //     if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != '1') return;

    //     grid[r][c] = '0';
    //     dfs(r + 1, c, grid);
    //     dfs(r - 1, c, grid);
    //     dfs(r, c + 1, grid);
    //     dfs(r, c - 1, grid);
    // }

    // public void bfs(int r, int c, char[][] grid){
    //     Queue<(int,int)> queue = new();
    //     grid[r][c] = '0';
    //     queue.Enqueue((r,c));
        
    //     while(queue.Count > 0){
    //         (int i, int j) = queue.Dequeue();
    //         foreach(var dir in directions){
    //             int nrr = i + dir[0];
    //             int nrc = j + dir[1];
    //             if(nrr < grid.Length && nrr >= 0 && nrc < grid[0].Length && nrc >= 0 && grid[nrr][nrc] == '1'){
    //                 grid[nrr][nrc] = '0';
    //                 queue.Enqueue((nrr,nrc));
    //             }
    //         }
    //     }
    // }

    public void dfs(int r, int c, char[][] grid){
        Stack<(int,int)> stack = new();
        grid[r][c] = '0';
        stack.Push((r,c));
        
        while(stack.Count > 0){
            (int i, int j) = stack.Pop();
            foreach(var dir in directions){
                int nrr = i + dir[0];
                int nrc = j + dir[1];
                if(nrr < grid.Length && nrr >= 0 && nrc < grid[0].Length && nrc >= 0 && grid[nrr][nrc] == '1'){
                    grid[nrr][nrc] = '0';
                    stack.Push((nrr,nrc));
                }
            }
        }
    }
}
