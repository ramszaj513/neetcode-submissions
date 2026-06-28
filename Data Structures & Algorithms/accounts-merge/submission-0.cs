public class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x) {
        if (x != parent[x]) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;

        if (rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
            rank[rootX] += rank[rootY];
        } else {
            parent[rootX] = rootY;
            rank[rootY] += rank[rootX];
        }

        return true;
    }
}

public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        int n = accounts.Count;
        UnionFind uf = new UnionFind(n);
        Dictionary<string, int> emailToAcc = new Dictionary<string, int>();

        // Assign each email to an accountId
        // if the email was already assigned to some Id
        // union the corresponding account ids
        for (int i = 0; i < n; i++) {
            for (int j = 1; j < accounts[i].Count; j++) {
                string email = accounts[i][j];
                if (emailToAcc.ContainsKey(email)) {
                    uf.Union(i, emailToAcc[email]);
                } else {
                    emailToAcc[email] = i;
                }
            }
        }

        // Get group of emails for each account
        Dictionary<int, List<string>> emailGroup = new Dictionary<int, List<string>>();
        foreach (var kvp in emailToAcc) {
            string email = kvp.Key;
            int leader = uf.Find(kvp.Value);
            if (!emailGroup.ContainsKey(leader)) {
                emailGroup[leader] = new List<string>();
            }
            emailGroup[leader].Add(email);
        }

        // Prepare the final result
        // Append name and then the email group to the each list item
        List<List<string>> res = new List<List<string>>();
        foreach (var kvp in emailGroup) {
            int accId = kvp.Key;
            List<string> emails = kvp.Value;
            emails.Sort(StringComparer.Ordinal);
            List<string> merged = new List<string> { accounts[accId][0] };
            merged.AddRange(emails);
            res.Add(merged);
        }

        return res;
    }
}