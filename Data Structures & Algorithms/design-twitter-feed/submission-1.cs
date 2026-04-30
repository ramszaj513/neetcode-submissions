public class Twitter {

    // the tweets are posted chronogicly so the is now need to sort them
    // each user should keep a List of followed poeple
    // each
    // the naive solution would be to keep the followers in a hashMap of hashMaps
    // where for each userid we get a map of who that person follows O(n^2) memory
    // when a tweet is posted can add it to the List,

    private Dictionary<int, HashSet<int>> followers;
    private Dictionary<int, List<(int id, int time)>> tweets;
    int order = 0;

    public Twitter() {
        this.followers = new Dictionary<int,HashSet<int>>();
        this.tweets = new Dictionary<int,List<(int,int)>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!tweets.ContainsKey(userId)){
            tweets[userId] = new List<(int,int)>();
        }
        tweets[userId].Add((tweetId,++order));
    }
    
    public List<int> GetNewsFeed(int userId) {
        var maxHeap = new PriorityQueue<(int uId, int index), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        
        HashSet<int> followees = followers.ContainsKey(userId) ? new HashSet<int>(followers[userId]) : new HashSet<int>();
        followees.Add(userId); 

        foreach (var followeeId in followees) {
            if (tweets.ContainsKey(followeeId) && tweets[followeeId].Count > 0) {
                int lastIdx = tweets[followeeId].Count - 1;
                int timestamp = tweets[followeeId][lastIdx].time;
                maxHeap.Enqueue((followeeId, lastIdx), timestamp);
                if (maxHeap.Count > 10) maxHeap.Dequeue();
            }
        }

        List<int> feed = new List<int>();
        while (maxHeap.Count > 0 && feed.Count < 10) {
            maxHeap.TryDequeue(out var node, out _);
            feed.Add(tweets[node.uId][node.index].id);
            if (node.index > 0) {
                int nextIdx = node.index - 1;
                int nextTimestamp = tweets[node.uId][nextIdx].time;
                maxHeap.Enqueue((node.uId, nextIdx), nextTimestamp);
            }
        }

        return feed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (followerId == followeeId) return;
        if (!followers.ContainsKey(followerId)) {
            followers[followerId] = new HashSet<int>();
        }
        followers[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (followers.ContainsKey(followerId)) {
            followers[followerId].Remove(followeeId);
        }
    }
}
