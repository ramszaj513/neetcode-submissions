public class Solution {
    private static readonly int[][] directions = new int[][]{
        new int[] {1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1}
    };

    public int MaxAreaOfIsland(int[][] grid) {
        int max = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){ 
                if(grid[i][j] == 1){
                    int area = bfs(i,j,grid);
                    max = int.Max(max,area);
                }
            }
        }
        return max;
    }

    public int bfs(int r, int c, int[][] grid){
        Queue<(int,int)> queue = new();
        grid[r][c] = 0;
        queue.Enqueue((r,c));
        int count = 1;
        
        while(queue.Count > 0){
            (int i, int j) = queue.Dequeue();
            foreach(var dir in directions){
                int nrr = i + dir[0];
                int nrc = j + dir[1];
                if(nrr < grid.Length && nrr >= 0 && nrc < grid[0].Length && nrc >= 0 && grid[nrr][nrc] == 1){
                    grid[nrr][nrc] = 0;
                    queue.Enqueue((nrr,nrc));
                    count++;
                }
            }
        }

        return count;
    }
}
