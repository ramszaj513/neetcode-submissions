public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] { 1, 0 }, 
        new int[] { -1, 0 }, 
        new int[] { 0, 1 }, 
        new int[] { 0, -1 }
    };

    public List<List<int>> PacificAtlantic(int[][] heights) {
        var result = new List<List<int>>();
        
        if (heights == null || heights.Length == 0 || heights[0].Length == 0) {
            return result;
        }

        int rows = heights.Length;
        int cols = heights[0].Length;

        bool[,] pacific = new bool[rows, cols];
        bool[,] atlantic = new bool[rows, cols];

        Queue<(int r, int c)> pacificQueue = new Queue<(int r, int c)>();
        Queue<(int r, int c)> atlanticQueue = new Queue<(int r, int c)>();

        for (int i = 0; i < rows; i++) {
            pacificQueue.Enqueue((i, 0));
            pacific[i, 0] = true;
            
            atlanticQueue.Enqueue((i, cols - 1));
            atlantic[i, cols - 1] = true;
        }
        
        for (int j = 0; j < cols; j++) {
            pacificQueue.Enqueue((0, j));
            pacific[0, j] = true;
            
            atlanticQueue.Enqueue((rows - 1, j));
            atlantic[rows - 1, j] = true;
        }

        Bfs(heights, pacificQueue, pacific);
        Bfs(heights, atlanticQueue, atlantic);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (pacific[i, j] && atlantic[i, j]) {
                    result.Add(new List<int> { i, j });
                }
            }
        }

        return result;
    }

    private void Bfs(int[][] heights, Queue<(int r, int c)> queue, bool[,] reachable) {
        int rows = heights.Length;
        int cols = heights[0].Length;
        
        while (queue.Count > 0) {
            var (r, c) = queue.Dequeue();

            foreach (var dir in directions) {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !reachable[nr, nc] && heights[nr][nc] >= heights[r][c]) {
                    reachable[nr, nc] = true;
                    queue.Enqueue((nr, nc));
                }
            }
        }
    }
}