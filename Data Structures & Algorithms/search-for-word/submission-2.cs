public class Solution {
    bool exist = false;

    public bool Exist(char[][] board, string word) {
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                if(board[i][j] == word[0]){
                    Search(0,i,j,word,board,new HashSet<(int,int)>{(i,j)});
                }
            }
        }

        return  exist;
    }

    private void Search(int i, int h, int w, string word, char[][] board, HashSet<(int,int)> visited){
        if(i == word.Length - 1){
            exist = true;
            return;
        }

        if(h > 0 && board[h-1][w] == word[i + 1] && !visited.Contains((h-1,w))){
            visited.Add((h-1,w));
            Search(i+1,h-1,w,word,board,visited);
            visited.Remove((h-1,w));
        } 
        if(h < board.Length - 1 && board[h+1][w] == word[i + 1] && !visited.Contains((h+1,w))){
            visited.Add((h+1,w));
            Search(i+1,h+1,w,word,board,visited);
            visited.Remove((h+1,w));
        }
        if(w > 0 && board[h][w-1] == word[i + 1] && !visited.Contains((h,w-1))){
            visited.Add((h,w-1));
            Search(i+1,h,w-1,word,board,visited);
            visited.Remove((h,w-1));
        } 
        if(w < board[0].Length - 1 && board[h][w+1] == word[i + 1] && !visited.Contains((h,w+1))){
            visited.Add((h,w+1));
            Search(i+1,h,w+1,word,board,visited);
            visited.Remove((h,w+1));
        }
    }
}
