public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        // we have a car with a a given capacity
        // it always goes right
        // trips[i] -> numPassengers from to

        // lets create a minHeap and insert the trips with priorities ebased on from
        // each time we take something off the first minHeap we add it to another heap to
        // where are the currently ongoing trips sorted by to values
        // in this process we track the current sum of people in the second heap

        PriorityQueue<(int people, int to), int> futureTrips = new();
        PriorityQueue<int, int> ongoingTrips = new();

        for(int i = 0; i < trips.Length; i++){
            futureTrips.Enqueue((trips[i][0], trips[i][2]), trips[i][1]);
        } 


        int currentPeople = 0;
        while(futureTrips.Count > 0){
            if(futureTrips.TryPeek(out _, out var p1) && ongoingTrips.TryPeek(out _, out var p2)){
                if(p2 <= p1){
                    int peopleIn = ongoingTrips.Dequeue();
                    currentPeople -= peopleIn;
                    continue;
                }
            }
            
            var (people, to) = futureTrips.Dequeue();
            currentPeople += people;
            if(currentPeople > capacity) return false;
            ongoingTrips.Enqueue(people,to);
        }

        return true;
    }
}