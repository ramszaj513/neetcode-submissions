public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // m * log(n)

        // binary search to find the right row
        // binary search in that row

        // log (n + m)

        int n = matrix.Length;
        int m = matrix[0].Length;

        int l = 0; 
        int r = n-1;

        while (l < r) {
            int mid = l + (r - l) / 2;
            if(target > matrix[mid][m - 1]) {
                l = mid + 1;
            } else {
                r = mid;
            }
        }
        int row = l;

        l = 0;
        r = m-1;

        while(l <= r){
            int mid = l + (r-l)/2;

            if(matrix[row][mid] == target){
                return true;
            }
            if(target < matrix[row][mid]){
                r = mid - 1;
            }
            else{
                l = mid + 1;
            }
        }

        return false;
    }
}
