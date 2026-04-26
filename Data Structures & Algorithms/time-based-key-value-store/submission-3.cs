public class TimeMap {
    // 1. Defined named tuples for high readability
    Dictionary<string, List<(string Value, int Timestamp)>> dict;

    public TimeMap() {
        dict = new Dictionary<string, List<(string Value, int Timestamp)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!dict.ContainsKey(key))
        {
            dict[key] = new List<(string Value, int Timestamp)>();
        }
        // Appending is O(1) and maintains the naturally sorted order
        dict[key].Add((value, timestamp)); 
    }
    
    public string Get(string key, int timestamp) {
        if (!dict.ContainsKey(key))
        {
            return "";
        }
        
        var list = dict[key];
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            // 2. Fixed: Safe middle calculation
            int middle = left + (right - left) / 2;

            // 3. Using our named tuple properties instead of Item1/Item2
            if (list[middle].Timestamp == timestamp)
            {
                return list[middle].Value;
            }
            
            if (list[middle].Timestamp > timestamp)
            {
                right = middle - 1;
            }
            else 
            {
                left = middle + 1;
            }
        }
        
        // 4. The Binary Search Floor Magic
        // 'right' is perfectly positioned at the largest valid timestamp.
        // If right went out of bounds (-1), no valid timestamp exists.
        return right >= 0 ? list[right].Value : "";
    }
}