using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int startRow = 0;
            int startCol = 1;
            int endRow = 4;
            int endCol = 3;
            int[][] graph = new int[][] {
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 1, 1, 1, 0},
            new int[] {0, 0, 0, 0, 0},
            new int[] {1, 0, 1, 1, 1},
            new int[] {0, 0, 0, 0, 0},
        };
        //    output = new int[][] {
        //    new int[] {0, 1},
        //    new int[] {0, 0},
        //    new int[] {1, 0},
        //    new int[] {2, 0},
        //    new int[] {2, 1},
        //    new int[] {3, 1},
        //    new int[] {4, 1},
        //    new int[] {4, 2},
        //    new int[] {4, 3}
        //};
            var output = A_StarAlgorithm(startRow, startCol, endRow, endCol, graph);
            Console.ReadLine();

        }

        public static int[][] A_StarAlgorithm(int startRow, int startCol, int endRow, int endCol, int[][] graph)
        {
            List<List<Node>> nodes = initializeNodes(graph);
            Node startNode = nodes[startRow][startCol];
            Node endNode = nodes[endRow][endCol];

            startNode.distanceFromStart = 0;
            startNode.estimatedDistanceToEnd = calculateManhattanDistance(startNode, endNode);

            List<Node> nodesToVisitList = new List<Node>();
            nodesToVisitList.Add(startNode);

            MinHeap nodesToVisit = new MinHeap(nodesToVisitList);

            while (!nodesToVisit.isEmpty())
            {
                Node currentMinDistanceNode = nodesToVisit.Remove();
                if (currentMinDistanceNode == endNode)
                {
                    break;
                }

                List<Node> neighbors = getNeighboringNodes(currentMinDistanceNode, nodes);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.val == 1)
                    {
                        continue;
                    }

                    int tentativeDistanceToNeighbor = currentMinDistanceNode.distanceFromStart + 1;
                    if (tentativeDistanceToNeighbor >= neighbor.distanceFromStart)
                    {
                        continue;
                    }
                    neighbor.nodeCameFrom = currentMinDistanceNode;
                    neighbor.distanceFromStart = tentativeDistanceToNeighbor;
                    neighbor.estimatedDistanceToEnd = neighbor.distanceFromStart + calculateManhattanDistance(neighbor, endNode);

                    if (!nodesToVisit.ContainsNode(neighbor))
                    {
                        nodesToVisit.Insert(neighbor);
                    }
                    else
                    {
                        nodesToVisit.Update(neighbor);
                    }
                }

            }
                return retrieveShortestPath(endNode);

        }

        private static List<List<Node>> initializeNodes(int[][] graph)
        {
            List<List<Node>> nodes = new List<List<Node>>();
            for(int i = 0; i < graph.Length; i++)
            {
                List<Node> nodeList = new List<Node>();
                for(int j = 0; j < graph[i].Length; j++)
                {
                    Node node = new Node(i, j, graph[i][j]);
                    nodeList.Add(node);
                }
                nodes.Add(nodeList);
            }

            return nodes;
        }

        private static int calculateManhattanDistance(Node currentNode, Node endNode)
        {
            int currentRow = currentNode.row;
            int currentCol = currentNode.col;
            int endRow = endNode.row;
            int endCol = endNode.col;

            int manhattanDistance = Math.Abs(endRow - currentRow) + Math.Abs(endCol - currentCol);
            return manhattanDistance;
        }

        private static List<Node> getNeighboringNodes(Node node, List<List<Node>> nodes)
        {
            int row = node.row;
            int col = node.col;
            int totalRows = nodes.Count;
            int totalCols = nodes[0].Count;
            List<Node> neighbors = new List<Node>();
            if (row > 0)
            {
                neighbors.Add(nodes[row - 1][col]);
            }
            if (row < totalRows - 1)
            {
                neighbors.Add(nodes[row + 1][col]);
            }
            if (col > 0)
            {
                neighbors.Add(nodes[row][col - 1]);
            }
            if (col < totalCols - 1)
            {
                neighbors.Add(nodes[row][col + 1]);
            }

            return neighbors;

        }

        private static int[][] retrieveShortestPath(Node endNode)
        {
            if(endNode.nodeCameFrom == null)
            {
                return new int[][] { };
            }
            List<List<int>> path = new List<List<int>>();
            Node currentNode = endNode;

            while(currentNode != null)
            {
                List<int> rowCol = new List<int>();
                rowCol.Add(currentNode.row);
                rowCol.Add(currentNode.col);
                path.Add(rowCol);
                currentNode = currentNode.nodeCameFrom;
            }

            int[][] actualPath = new int[path.Count][];
            for(int i = 0; i < path.Count; i++)
            {
                actualPath[i] = path[path.Count - 1 -i].ToArray();
            }

            return actualPath;
        }

        public class Node
        {
            public string id;
            public int row;
            public int col;
            public int val;
            public int distanceFromStart;
            public int estimatedDistanceToEnd;
            public Node nodeCameFrom;

            public Node(int row, int col, int val)
            {
                id = row.ToString() + '-' + col.ToString();
                this.row = row;
                this.col = col;
                this.val = val;
                distanceFromStart = int.MaxValue;
                estimatedDistanceToEnd = int.MaxValue;
                nodeCameFrom = null;
            }
        }

        public class MinHeap
        {
            public Dictionary<string, int> nodesPositionsInheap= new Dictionary<string, int>();
            public List<Node> heap = new List<Node>();

            public MinHeap(List<Node> list)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    nodesPositionsInheap.Add(list[i].id, i);
                }

                heap = BuildHeap(list);
            }

            private List<Node> BuildHeap(List<Node> list)
            {
                if(list.Count <= 1)
                {
                    return list;
                }
                int firstParentIndex = (list.Count - 2)/ 2;
                for(int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
                {
                    SiftDown(currentIndex, list.Count - 1, list); 
                }

                return list;
            }

            private void SiftDown(int currentIndex, int endIndex, List<Node> list)
            {
                int child1Idx = (2 * currentIndex) + 1;
                while (child1Idx <= endIndex)
                {
                    int child2Idx = (2 * currentIndex) + 2;
                    int indexToSwap;
                    if (child2Idx <= endIndex && list[child2Idx].estimatedDistanceToEnd < list[child1Idx].estimatedDistanceToEnd)
                    {
                        indexToSwap = child2Idx;
                    }
                    else
                    {
                        indexToSwap = child1Idx;
                    }


                    if(list[indexToSwap].estimatedDistanceToEnd < list[currentIndex].estimatedDistanceToEnd)
                    {
                        Swap(indexToSwap, currentIndex);
                        currentIndex = indexToSwap;
                        child1Idx = (2 * currentIndex) + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void SiftUp(int currentIndex)
            {
                int parentIndex = (currentIndex - 1) / 2;
                while(currentIndex > 0 && heap[currentIndex].estimatedDistanceToEnd < heap[parentIndex].estimatedDistanceToEnd)
                {
                    Swap(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                    parentIndex = (currentIndex - 1) / 2;
                }
            }

            public Node Remove()
            {
                if (isEmpty())
                {
                    return null;
                }
                Swap(0, heap.Count - 1);
                Node nodeToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                nodesPositionsInheap.Remove(nodeToRemove.id);
                SiftDown(0, heap.Count - 1, heap);
                return nodeToRemove;
            }
            public void Insert(Node node)
            {
                heap.Add(node);
                nodesPositionsInheap.Add(node.id, heap.Count - 1);
                SiftUp(heap.Count - 1);
            }

            public void Update(Node node)
            {
                SiftUp(nodesPositionsInheap[node.id]);
            }

            public bool ContainsNode(Node node)
            {
                return nodesPositionsInheap.ContainsKey(node.id);
            }

            public bool isEmpty()
            {
                return heap.Count == 0;
            }

            public void Swap(int i, int j)
            {
                nodesPositionsInheap[heap[i].id] = j;
                nodesPositionsInheap[heap[j].id] = i;
                Node temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }

       

        //public static int[][] A_StarAlgorithm(int startRow, int startCol, int endRow, int endCol, int[][] graph)
        //{
        //    // Write your code here.
        //    //T.C is O(W * H * LOG(W * H) ) and S.C is O(W * H);
        //    // W is the width and H is the Height of the Graph
        //    List<List<Node>> nodes = initializeNodes(graph);
        //    Node startNode = nodes[startRow][startCol];
        //    Node endNode = nodes[endRow][endCol];

        //    startNode.distanceFromStart = 0;
        //    startNode.estimatedDistanceToEnd = calculateManhattanDistance(startNode, endNode);

        //    List<Node> nodesToVisitList = new List<Node>();
        //    nodesToVisitList.Add(startNode);
        //    MinHeap nodesToVisit = new MinHeap(nodesToVisitList);

        //    while (!nodesToVisit.isEmpty())
        //    {
        //        Node currentMinDistanceNode = nodesToVisit.Remove();
        //        if (currentMinDistanceNode == endNode)
        //        {
        //            break;
        //        }

        //        List<Node> neighbors = getNeighboringNodes(currentMinDistanceNode, nodes);
        //        foreach (var neighbor in neighbors)
        //        {
        //            if (neighbor.value == 1)
        //            {
        //                continue;
        //            }

        //            int tentativeDistanceToNeighbor = currentMinDistanceNode.distanceFromStart + 1;

        //            if (tentativeDistanceToNeighbor >= neighbor.distanceFromStart)
        //            {
        //                continue;
        //            }

        //            neighbor.cameFrom = currentMinDistanceNode;
        //            neighbor.distanceFromStart = tentativeDistanceToNeighbor;
        //            neighbor.estimatedDistanceToEnd = tentativeDistanceToNeighbor +
        //                calculateManhattanDistance(neighbor, endNode);

        //            if (!nodesToVisit.ContainsNode(neighbor))
        //            {
        //                nodesToVisit.Insert(neighbor);
        //            }
        //            else
        //            {
        //                nodesToVisit.Update(neighbor);
        //            }

        //        }
        //    }

        //    return reconstructPath(endNode);
        //}

        //public static int[][] reconstructPath(Node endNode)
        //{
        //    if (endNode.cameFrom == null)
        //    {
        //        return new int[][] { };
        //    }
        //    Node currentNode = endNode;
        //    List<List<int>> path = new List<List<int>>();

        //    while (currentNode != null)
        //    {
        //        List<int> nodeData = new List<int>();
        //        nodeData.Add(currentNode.row);
        //        nodeData.Add(currentNode.col);
        //        path.Add(nodeData);
        //        currentNode = currentNode.cameFrom;
        //    }

        //    int[][] res = new int[path.Count][];
        //    for (int i = 0; i < res.Length; i++)
        //    {
        //        res[i] = path[res.Length - 1 - i].ToArray();
        //    }

        //    return res;
        //}

        //public static List<List<Node>> initializeNodes(int[][] graph)
        //{
        //    List<List<Node>> nodes = new List<List<Node>>();

        //    for (int i = 0; i < graph.Length; i++)
        //    {
        //        List<Node> nodeList = new List<Node>();
        //        nodes.Add(nodeList);
        //        for (int j = 0; j < graph[i].Length; j++)
        //        {
        //            nodes[i].Add(new Node(i, j, graph[i][j]));
        //        }
        //    }
        //    return nodes;
        //}

        ////h score
        //public static int calculateManhattanDistance(Node currentNode, Node endNode)
        //{

        //    int currentRow = currentNode.row;
        //    int currentCol = currentNode.col;
        //    int endRow = endNode.row;
        //    int endCol = endNode.col;

        //    return Math.Abs(currentRow - endRow) + Math.Abs(currentCol - endCol);
        //}

        //public static List<Node> getNeighboringNodes(Node node, List<List<Node>> nodes)
        //{
        //    List<Node> neighbors = new List<Node>();

        //    int numRows = nodes.Count;
        //    int numCols = nodes[0].Count;

        //    int row = node.row;
        //    int col = node.col;

        //    if (row < numRows - 1)
        //    {
        //        neighbors.Add(nodes[row + 1][col]);
        //    }
        //    if (row > 0)
        //    {
        //        neighbors.Add(nodes[row - 1][col]);
        //    }
        //    if (col < numCols - 1)
        //    {
        //        neighbors.Add(nodes[row][col + 1]);
        //    }
        //    if (col > 0)
        //    {
        //        neighbors.Add(nodes[row][col - 1]);
        //    }

        //    return neighbors;
        //}
        //public class Node
        //{
        //    public string id;
        //    public int row;
        //    public int col;
        //    public int value;
        //    public int distanceFromStart;
        //    public int estimatedDistanceToEnd;
        //    public Node cameFrom;

        //    public Node(int row, int col, int value)
        //    {
        //        id = row.ToString() + '-' + col.ToString();
        //        this.row = row;
        //        this.col = col;
        //        this.value = value;
        //        //g
        //        distanceFromStart = int.MaxValue;
        //        //f
        //        estimatedDistanceToEnd = int.MaxValue;
        //        cameFrom = null;
        //    }
        //}

        //public class MinHeap
        //{
        //    Dictionary<string, int> nodePositionsInHeap = new Dictionary<string, int>();
        //    List<Node> heap = new List<Node>();

        //    public MinHeap(List<Node> list)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            nodePositionsInHeap[list[i].id] = i;
        //        }
        //        heap = buildHeap(list);
        //    }

        //    public List<Node> buildHeap(List<Node> array)
        //    {
        //        // Write your code here.
        //        if (array.Count <= 1)
        //        {
        //            return array;
        //        }
        //        int firstParentIdx = (array.Count - 2) / 2;
        //        for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
        //        {
        //            siftDown(currentIdx, array.Count - 1, array);
        //        }
        //        return array;
        //    }

        //    public bool isEmpty()
        //    {
        //        return heap.Count == 0;
        //    }

        //    //T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
        //    public void siftDown(int currentIdx, int endIdx, List<Node> heap)
        //    {
        //        // Write your code here.
        //        //Get ChildNodes
        //        int childNode1_Idx = (2 * currentIdx) + 1;
        //        while (childNode1_Idx <= endIdx)
        //        {
        //            int childNode2_Idx = (2 * currentIdx) + 2;
        //            int indexToSwap;
        //            if (childNode2_Idx <= endIdx && heap[childNode2_Idx].estimatedDistanceToEnd
        //                 < heap[childNode1_Idx].estimatedDistanceToEnd)
        //            {
        //                indexToSwap = childNode2_Idx;
        //            }
        //            else
        //            {
        //                indexToSwap = childNode1_Idx;
        //            }

        //            if (heap[indexToSwap].estimatedDistanceToEnd
        //                 < heap[currentIdx].estimatedDistanceToEnd)
        //            {
        //                Swap(indexToSwap, currentIdx);
        //                currentIdx = indexToSwap;
        //                childNode1_Idx = (2 * currentIdx) + 1;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        }
        //    }

        //    //T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
        //    public void siftUp(int currentIdx)
        //    {
        //        // Write your code here.
        //        int parentIdx = (currentIdx - 1) / 2;
        //        while (currentIdx > 0 && heap[currentIdx].estimatedDistanceToEnd
        //                    < heap[parentIdx].estimatedDistanceToEnd)
        //        {
        //            //swap
        //            Swap(currentIdx, parentIdx);
        //            currentIdx = parentIdx;
        //            parentIdx = (currentIdx - 1) / 2;
        //        }
        //    }

        //    //T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
        //    public Node Remove()
        //    {
        //        // Write your code here.
        //        if (isEmpty())
        //        {
        //            return null;
        //        }
        //        Swap(0, heap.Count - 1);
        //        Node node = heap[heap.Count - 1];
        //        heap.RemoveAt(heap.Count - 1);
        //        nodePositionsInHeap.Remove(node.id);
        //        siftDown(0, heap.Count - 1, heap);
        //        return node;
        //    }

        //    public void Insert(Node node)
        //    {
        //        heap.Add(node);
        //        nodePositionsInHeap[node.id] = heap.Count - 1;
        //        siftUp(heap.Count - 1);
        //    }

        //    public void Update(Node node)
        //    {
        //        siftUp(nodePositionsInHeap[node.id]);
        //    }

        //    public bool ContainsNode(Node node)
        //    {
        //        return nodePositionsInHeap.ContainsKey(node.id);
        //    }

        //    //T.C is O(1) and S.C IS O(1)
        //    public void Swap(int i, int j)
        //    {
        //        nodePositionsInHeap[heap[i].id] = j;
        //        nodePositionsInHeap[heap[j].id] = i;
        //        Node temp = heap[i];
        //        heap[i] = heap[j];
        //        heap[j] = temp;
        //    }
        //}
    }
}
