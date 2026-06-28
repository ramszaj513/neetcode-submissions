public class Solution {
    public int OpenLock(string[] deadends, string target) {
        // we have a locks with 4 wheels
        // each one can go to the next value in both direction
        // they can only go one shot

        HashSet<string> ends = new HashSet<string>(deadends);
        if(ends.Contains("0000")) return -1;

        HashSet<string> visited = new HashSet<string>();
        visited.Add("0000");

        Queue<(string,int)> q = new Queue<(string,int)>();
        q.Enqueue(("0000",0));

        List<string> children(string comb){
            List<string> res = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                char[] chars = comb.ToCharArray();
                int num = chars[i] - '0';
                
                int increment = (num + 1) % 10;
                int decrement = (num - 1 + 10) % 10;
                
                chars[i] = (char)(increment + '0');
                res.Add(new string(chars));
                
                chars[i] = (char)(decrement + '0');
                res.Add(new string(chars));
            }

            return res;
        }

        while(q.Count > 0){
            (var val, var turn) = q.Dequeue();
            
            if(val == target) return turn;

            foreach(var child in children(val)){
                if(ends.Contains(child)) continue;

                if(!visited.Contains(child)){
                    q.Enqueue((child, turn+1));
                    visited.Add(child);
                }
            }
        }

        return -1;
    }
}