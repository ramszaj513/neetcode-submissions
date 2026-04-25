public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // m * log(n)

        // binary search to find the right row
        // binary search in that row

        // log (n + m)

        int l = 0; 
        int r = matrix.Length*matrix[0].Length -1;

        while (l <= r) {
            int mid = l + (r - l) / 2;

            int val = matrix[mid / matrix[0].Length][mid % matrix[0].Length];

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
