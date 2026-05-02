public class PrefixTree {

    private class Node{
        public Dictionary<char,Node> children = new Dictionary<char,Node>();
        public bool isEnd = false;
    }

    private Node root;

    public PrefixTree() {
        root = new Node();
    }
    
    public void Insert(string word) {
        Node node = root;
        foreach(var c in word){
            if(!node.children.ContainsKey(c)){
                node.children[c] = new Node();
            }
            node = node.children[c];
        }
        node.isEnd = true;
    }
    
    public bool Search(string word) {
        Node node = root;
        foreach(var c in word){
            if(!node.children.ContainsKey(c)) return false;
            node = node.children[c];
        }
        return node.isEnd;
    }
    
    public bool StartsWith(string prefix) {
        Node node = root;
        foreach(var c in prefix){
            if(!node.children.ContainsKey(c)) return false;
            node = node.children[c];
        }
        return true;
    }
}
