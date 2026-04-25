public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // m * log(n)

        // binary search to find the right row
        // binary search in that row

        // log (n + m)

        int n = matrix.Length;
        int m = matrix[0].Length;

        int l = 0; 
        int r = n*m -1;

        while (l <= r) {
            int mid = l + (r - l) / 2;

            int val = matrix[mid / m][mid % m];

            if(target == val) return true;
            if(target > val) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }

        return false;
    }
}
