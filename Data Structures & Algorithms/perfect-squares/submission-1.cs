public class Solution {
    public int NumSquares(int n) {
        // we have integer n we have to tell how many perfect squares can sum up to it

        // each time the value we are searching for is larger than sum new square we can just tell the 1 + the rest
        // so lets say the value is 18 -> 16 + 1 > squares[2]

        // I can go lineary starting from [0,1,....]
        // each time there is a new perfect squere i set it to 1 then I add the value from the difference
        // so I have to fill the values until I reach the perfect square which is the largest

        // how do I check if somthing is a perfect square?
        // I can fill the table with sqaures first (then if it is equal to one it means it is a perfect squre)
        // I stop filling when the square is bigger than the value I am searching for

        // time complexity would be O(n)

        int[] squares = new int[n+1];
        Array.Fill(squares, n);
        squares[0] = 0;

        for(int i = 1; i <= n; i++){
            for(int s = 1; s*s <= i; s++){
                int newSquare = s*s;
                squares[i] = Math.Min(squares[i], 1 + squares[i - newSquare]);
            }
        }

        return squares[n];
    }
}