public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        int[] arr = (int[])nums.Clone();
        Array.Sort(arr);
        int n = arr.Length;

        List<List<int>> results = new List<List<int>>();

        for(int i = 0; i < n - 2; i++) {
            if (arr[i] > 0) break;

            if (i > 0 && arr[i] == arr[i - 1]) continue;

            int left = i + 1;
            int right = n - 1;

            while(left < right) {
                int sum = arr[i] + arr[left] + arr[right];

                if(sum == 0) {
                    results.Add(new List<int>{arr[i], arr[left], arr[right]});

                    while (left < right && arr[left] == arr[left + 1]) left++;
                    while (left < right && arr[right] == arr[right - 1]) right--;

                    left++;
                    right--;
                }
                else if(sum < 0) {
                    left++;
                }
                else {
                    right--;
                }
            }
        }
        return results;
    }
}