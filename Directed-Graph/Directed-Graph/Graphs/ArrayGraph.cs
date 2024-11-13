using Directed_Graph.Exceptions;
using System.Collections;

namespace Directed_Graph.Graphs
{
	public class ArrayGraph<N, L> : IGraph<N, L>
	{
		private N[] nodes;                   // Массив узлов фиксированной длины

		/// <summary>
		/// Матрица смежности. В ней мы записываем связь только в одном направлении — от узла node1 к node2.
		/// </summary>
		private L[,] links;

		private int nodeCount = 0;                    // Счетчик добавленных узлов
		private readonly Dictionary<N, int> nodeIndices; // Сопоставление узлов с их индексами в массиве

		public ArrayGraph()
		{
			nodes = new N[1];
			links = new L[1, 1];
			nodeIndices = new Dictionary<N, int>(1);
		}

		public void AddNode(N node)
		{
			if (node == null)
				throw new NullReferenceGraphException();

			if (nodeIndices.ContainsKey(node))
				throw new GraphException("Узел уже существует в графе.");

			if (nodeCount >= nodes.Length)
				ExpandGraphCapacity();

			nodes[nodeCount] = node;
			nodeIndices[node] = nodeCount;
			nodeCount++;
		}

		private void ExpandGraphCapacity()
		{
			int newSize = nodes.Length * 2;
			Array.Resize(ref nodes, newSize);

			var newLinks = new L[newSize, newSize];
			for (int i = 0; i < nodeCount; i++)
				for (int j = 0; j < nodeCount; j++)
					newLinks[i, j] = links[i, j];

			links = newLinks;
		}

		public void AddLink(N node1, N node2, L link)
		{
			if (!nodeIndices.ContainsKey(node1) || !nodeIndices.ContainsKey(node2))
				throw new GraphException("Оба узла должны существовать в графе.");

			int index1 = nodeIndices[node1];
			int index2 = nodeIndices[node2];
			links[index1, index2] = link;  // Добавление связи в матрицу смежности
		}

		public void Clear()
		{
			Array.Clear(nodes, 0, nodes.Length);
			Array.Clear(links, 0, links.Length);
			nodeIndices.Clear();
			nodeCount = 0;
		}

		public bool Contains(N node) => nodeIndices.ContainsKey(node);

		public void Remove(N node)
		{
			if (!nodeIndices.TryGetValue(node, out int index))
				throw new GraphException("Узел не найден в графе.");

			// Удаляем узел из nodes и перемещаем оставшиеся узлы для заполнения "дыры"
			nodeIndices.Remove(node);
			for (int i = index; i < nodeCount - 1; i++)
			{
				nodes[i] = nodes[i + 1];
				nodeIndices[nodes[i]] = i;

				for (int j = 0; j < nodeCount; j++)
				{
					links[i, j] = links[i + 1, j];
					links[j, i] = links[j, i + 1];
				}
			}

			N? valueL = default;
			nodes[nodeCount - 1] = valueL;
			nodeCount--;
		}

		public int Count => nodeCount;
		public bool IsEmpty => nodeCount == 0;
		public IEnumerable<N> Nodes
		{
			get
			{
				for (int i = 0; i < nodeCount; i++)
				{
					yield return nodes[i];
				}
			}
		}

		public IEnumerator<N> GetEnumerator()
		{
			for (int i = 0; i < nodeCount; i++)
				yield return nodes[i];
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
