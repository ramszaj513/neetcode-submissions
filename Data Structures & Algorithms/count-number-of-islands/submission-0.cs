public class Solution {
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

    public void dfs(int r, int c, char[][] grid){
        if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '#' || grid[r][c] != '1') return;

        grid[r][c] = '#';
        dfs(r + 1, c, grid);
        dfs(r - 1, c, grid);
        dfs(r, c + 1, grid);
        dfs(r, c - 1, grid);
    }
}
