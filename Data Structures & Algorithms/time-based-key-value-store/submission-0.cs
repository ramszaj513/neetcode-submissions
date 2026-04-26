public class TimeMap {

    // we need to be bale to store multiple values for the same key in one timestamp

    // HashMap<string,List<(value,timestamp)>>
    // (vlaue, timestamp)
    // binary sort to get the exact timestamp or the one below it if there isnt one return ""

    // Set
    // O(1)

    // Get
    // O(log(n))

    Dictionary<string, List<(int timestamp,string val)>> map = new Dictionary<string, List<(int timestamp,string val)>>();

    public TimeMap() {}
    
    public void Set(string key, string value, int timestamp) {
        if(map.ContainsKey(key)){
            map[key].Add((timestamp,value));
        }
        else{
            map[key] = new List<(int timestamp,string value)> { (timestamp, value) };
        }
    }
    
    public string Get(string key, int timestamp) {
        if(!map.ContainsKey(key)) return "";

        var values = map[key];

        int l = 0;
        int r = values.Count - 1;
        string res = "";
        while(l <= r){
            int mid = l + (r - l)/2;

            if(values[mid].timestamp <= timestamp) {
                res = values[mid].val;
                l = mid + 1;
            }
            else{
                r = mid - 1;
            }

        }
        return res;
    }
}
