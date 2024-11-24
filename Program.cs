var graph = new Graph();


//graph.AddEdge(1, 2);
//graph.AddEdge(1, 3);
//graph.AddEdge(2, 4);
//graph.AddEdge(3, 5);

//var path = BFS.FindShortestPath(graph, 1, 5);


graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 3);

var path = BFS.FindShortestPath(graph, 0, 3);


//graph.AddEdge(1, 2);
//graph.AddEdge(1, 3);
//graph.AddEdge(2, 4);
//graph.AddEdge(3, 5);

//var path = BFS.FindShortestPath(graph, 1, 5);


//graph.AddEdge(1, 2);
//graph.AddEdge(2, 3);
//graph.AddEdge(3, 4);
//graph.AddEdge(4, 5);
//graph.AddEdge(6, 7);

//var path = BFS.FindShortestPath(graph, 1, 7);


Console.WriteLine(path == null ? "Path not found" : string.Join("->", path));



class BFS
{
    public static List<int> FindShortestPath(Graph graph, int start, int goal)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int> { start });

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var node = path[^1];

            if (node == goal)
                return path;

            if (!visited.Contains(node))
            {
                visited.Add(node);

                foreach (var neighbor in graph.AdjacencyList[node])
                {
                    var newPath = new List<int>(path) { neighbor };
                    queue.Enqueue(newPath);
                }
            }
        }

        return null; // Путь не найден
    }
}


class Graph
{
    public Dictionary<int, List<int>> AdjacencyList { get; private set; }

    public Graph()
    {
        AdjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int u, int v)
    {
        if (!AdjacencyList.ContainsKey(u))
        {
            AdjacencyList[u] = new List<int>();
        }
        if (!AdjacencyList.ContainsKey(v))
        {
            AdjacencyList[v] = new List<int>();
        }

        AdjacencyList[u].Add(v);
        AdjacencyList[v].Add(u);
    }
}


