public class TimeMap {
    private readonly Dictionary<string, List<(int Time, string Val)>> _map;

    public TimeMap() {
        _map = new Dictionary<string, List<(int, string)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!_map.TryGetValue(key, out var list)) {
            list = new List<(int, string)>();
            _map[key] = list;
        }
        list.Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        if (!_map.TryGetValue(key, out var values)) return "";

        int l = 0;
        int r = values.Count - 1;
        
        if (values[0].Time > timestamp) return "";
        if (values[r].Time <= timestamp) return values[r].Val;

        string res = "";
        while (l <= r) {
            int mid = l + (r - l) / 2;
            
            if (values[mid].Time <= timestamp) {
                res = values[mid].Val;
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return res;
    }
}
