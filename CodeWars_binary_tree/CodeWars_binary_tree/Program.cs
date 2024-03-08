// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var test = TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1));
Console.WriteLine("Rjtrw");



static List<int> TreeByLevels(Node root)
{
    if (root == null)
        return null;

    var queue = new Queue<Node>();
    queue.Enqueue(root);
    var levels = new List<int>();

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        levels.Add(node.Value);

        if (node.Left != null)
            queue.Enqueue(node.Left);
        if (node.Right != null)
            queue.Enqueue(node.Right);
    }
    return levels;
}
static List<int> LevelsChildren(Node node)
{
    if (node == null)
    {
        return new List<int>();
    }
    else
    {
        var levels = new List<int> { node.Value };
        levels.AddRange(LevelsChildren(node.Left));
        levels.AddRange(LevelsChildren(node.Right));
        return levels;
    }
}
public class Node
{
    public Node Left;
    public Node Right;
    public int Value;

    public Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}