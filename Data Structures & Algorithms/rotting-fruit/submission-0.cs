public class Solution {
    public int OrangesRotting(int[][] grid) {
        // enqueue all of the rotten fruits
        // save the minute (it will basicly be a bfs waves)
        // keep track of the recent minute number
        // end when there is nothing in the queue
        // return the recent minute number
        Queue<((int,int),int)> q = new Queue<((int,int),int)>();
        int count = 0;
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 2) q.Enqueue(((i,j),0));
                if(grid[i][j] == 1) count++;
            }
        }

        int[][] dirs = new int[][]{
            new int[]{0,1}, new int[]{0,-1}, new int[]{1,0}, new int[]{-1,0}
        };

        int minuteCount = 0;

        while(q.Count > 0){
            ((var r, var c), var minute) = q.Dequeue();
            foreach(var dir in dirs){
                int nr = r + dir[0];
                int nc = c + dir[1];
                if(nr < grid.Length && nr >= 0 && nc < grid[0].Length && nc >= 0 && grid[nr][nc] == 1){
                    grid[nr][nc] = 2;
                    q.Enqueue(((nr,nc), minute + 1));
                    minuteCount = minute + 1;
                    count--;
                }
            }
        }

        return count == 0 ? minuteCount : -1;
    }
}
