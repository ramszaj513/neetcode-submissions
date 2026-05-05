public class Solution {
    private static int[][] directions = new int[][]{
        new int[]{-1,0}, new int[]{1,0}, new int[]{0,1}, new int[]{0,-1}
    };

    public void islandsAndTreasure(int[][] grid) {
        // start bfs from each 0 at once
        // if some value is already smaller than int.MaxValue -1
        // we dont need to touch it becuase it is closer to some other chest

        Queue<(int,int)> q = new Queue<(int,int)>();
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 0){
                    q.Enqueue((i,j));
                }
            }
        }

        while(q.Count > 0){
            (var r, var c) = q.Dequeue();
            int newDist = grid[r][c] + 1;
            foreach(var dir in directions){
                if(r + dir[0] >= 0 && r + dir[0] < grid.Length && c + dir[1] < grid[0].Length && c + dir[1] >= 0 && grid[r + dir[0]][c + dir[1]] > newDist){
                    grid[r + dir[0]][c + dir[1]] = newDist;
                    q.Enqueue((r + dir[0],c + dir[1]));
                }
            }
        }
    }
}
