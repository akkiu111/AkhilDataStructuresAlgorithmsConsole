using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstrasAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {

			int[][][] edges =
			{
		    new int[][] {new int[] {1 ,7}},
		    new int[][] {new int[] {2, 6}, new int[] {3, 20}, new int[] {4, 3}},
			new int[][] {new int[] {3, 14}},
			new int[][] {new int[] {4, 2}},
			new int[][] {},
			new int[][] {}

			};

			//int[] expected = {0, 7, 13, 27, 10, -1};

			var output = DijkstrasAlgorithm(0, edges);
			Console.ReadLine();

		}
   
		public static int[] DijkstrasAlgorithm(int start, int[][][] edges)
		{
			// Write your code here.
			// T.C is O((V+E) * LOG(V)) and S.C is O(V) where V is the number of vertices 
			// and E are the number of Edges;
			int numberOfVertices = edges.Length;
			int[] minDistances = new int[numberOfVertices];
			List<Element> minDistancePairs = new List<Element>();
			for (int i = 0; i < numberOfVertices; i++)
			{
				minDistances[i] = int.MaxValue;
				Element ele = new Element(i, int.MaxValue);
				minDistancePairs.Add(ele);
			}

			minDistances[start] = 0;

			MinHeap minDistancesHeap = new MinHeap(minDistancePairs);
			minDistancesHeap.Update(start, 0);

			while (!minDistancesHeap.isEmpty())
			{
				Element heapEle = minDistancesHeap.Remove();
				int vertex = heapEle.vertex;
				int currentMinDistance = heapEle.distance;

				if (currentMinDistance == int.MaxValue)
				{
					break;
				}

				foreach (var edge in edges[vertex])
				{
					int destinationVertex = edge[0];
					int distanceToDestinationVertex = edge[1];
					int newPathDistance = currentMinDistance + distanceToDestinationVertex;
					int currentDestinationDistance = minDistances[destinationVertex];

					if (newPathDistance < currentDestinationDistance)
					{
						minDistances[destinationVertex] = newPathDistance;
						minDistancesHeap.Update(destinationVertex, newPathDistance);
					}
				}
			}

			for (int i = 0; i < minDistances.Length; i++)
			{
				if (minDistances[i] == int.MaxValue)
				{
					minDistances[i] = -1;
				}
			}

			return minDistances;
		}

		public class Element
		{
			public int vertex;
			public int distance;

			public Element(int vertex, int distance)
			{
				this.vertex = vertex;
				this.distance = distance;
			}
		}

		public class MinHeap
		{
			Dictionary<int, int> vertexDictionary = new Dictionary<int, int>();
			List<Element> heap = new List<Element>();

			public MinHeap(List<Element> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					vertexDictionary[list[i].vertex] = list[i].vertex;
				}
				heap = buildHeap(list);
			}

			public List<Element> buildHeap(List<Element> array)
			{
				// Write your code here.
				if (array.Count <= 1)
				{
					return array;
				}
				int firstParentIdx = (array.Count - 2) / 2;
				for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
				{
					siftDown(currentIdx, array.Count - 1, array);
				}
				return array;
			}

			public bool isEmpty()
			{
				return heap.Count == 0;
			}

			//T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
			public void siftDown(int currentIdx, int endIdx, List<Element> heap)
			{
				// Write your code here.
				//Get ChildNodes
				int childNode1_Idx = (2 * currentIdx) + 1;
				while (childNode1_Idx <= endIdx)
				{
					int childNode2_Idx = (2 * currentIdx) + 2;
					int indexToSwap;
					if (childNode2_Idx <= endIdx && heap[childNode2_Idx].distance
						 < heap[childNode1_Idx].distance)
					{
						indexToSwap = childNode2_Idx;
					}
					else
					{
						indexToSwap = childNode1_Idx;
					}

					if (heap[indexToSwap].distance < heap[currentIdx].distance)
					{
						Swap(indexToSwap, currentIdx);
						currentIdx = indexToSwap;
						childNode1_Idx = (2 * currentIdx) + 1;
					}
					else
					{
						return;
					}
				}
			}

			//T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
			public void siftUp(int currentIdx)
			{
				// Write your code here.
				int parentIdx = (currentIdx - 1) / 2;
				while (currentIdx > 0 && heap[currentIdx].distance < heap[parentIdx].distance)
				{
					//Get the Parent Node
					//swap
					Swap(currentIdx, parentIdx);
					currentIdx = parentIdx;
					parentIdx = (currentIdx - 1) / 2;
				}
			}

			//T.C is O(Log(N)) and S.C iS O(1) where N is the length of the array
			public Element Remove()
			{
				// Write your code here.
				Swap(0, heap.Count - 1);
				Element lastElement = heap[heap.Count - 1];
				int vertex = lastElement.vertex;
				int distance = lastElement.distance;
				heap.RemoveAt(heap.Count - 1);
				vertexDictionary.Remove(vertex);
				siftDown(0, heap.Count - 1, heap);
				return new Element(vertex, distance);

			}

			public void Update(int vertex, int value)
			{
				heap[vertexDictionary[vertex]] = new Element(vertex, value);
				siftUp(vertexDictionary[vertex]);
			}

			//T.C is O(1) and S.C IS O(1)
			public void Swap(int i, int j)
			{
				vertexDictionary[heap[i].vertex] = j;
				vertexDictionary[heap[j].vertex] = i;
				Element temp = heap[i];
				heap[i] = heap[j];
				heap[j] = temp;
			}
		}
	}

}
