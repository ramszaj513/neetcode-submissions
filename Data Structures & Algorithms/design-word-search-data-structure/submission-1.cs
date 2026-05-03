public class WordDictionary {
    private class Node{
        public Dictionary<char,Node> children = new Dictionary<char,Node>();
        public bool isEnd = false;
    }
    private Node root;

    public WordDictionary() {
        root = new Node();
    }
    
    public void AddWord(string word) {
        Node curr = root;
        foreach(var letter in word){
            if(!curr.children.ContainsKey(letter)){
                curr.children[letter] = new Node();
            }
            curr = curr.children[letter];
        }
        curr.isEnd = true;
    }
    
    public bool Search(string word) {
        Queue<(Node,int)> queue = new Queue<(Node,int)>();
        queue.Enqueue((root,0));

        while(queue.Count > 0){
            (var node, var index) = queue.Dequeue();
            if(index == word.Length){
                if(node.isEnd) return true;
                continue;
            }

            if(word[index] == '.'){
                foreach(var child in node.children.Values){
                    queue.Enqueue((child,index + 1));
                }
            } else{
                if(node.children.ContainsKey(word[index])){
                    queue.Enqueue((node.children[word[index]], index + 1));
                }
            }
        }

        return false;
    }
}
