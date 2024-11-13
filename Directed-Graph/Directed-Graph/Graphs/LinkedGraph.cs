using Directed_Graph.Exceptions;
using System.Collections;

namespace Directed_Graph.Graphs
{
	public class LinkedGraph<N, L> : IGraph<N, L>
	{
		private readonly Dictionary<N, LinkedGraphNode<N, L>> nodes;  // Сопоставление значения узла с объектом Node

		public LinkedGraph()
		{
			nodes = new Dictionary<N, LinkedGraphNode<N, L>>();
		}

		public void AddNode(N nodeValue)
		{
			if (nodeValue == null)
				throw new NullReferenceGraphException();

			if (nodes.ContainsKey(nodeValue))
				throw new GraphException("Узел уже существует в графе.");

			// Создаем новый узел и добавляем его в граф
			nodes[nodeValue] = new LinkedGraphNode<N, L>(nodeValue);
		}

		public void AddLink(N nodeValue1, N nodeValue2, L link)
		{
			if (!nodes.ContainsKey(nodeValue1) || !nodes.ContainsKey(nodeValue2))
				throw new GraphException("Оба узла должны существовать в графе.");

			LinkedGraphNode<N, L> node1 = nodes[nodeValue1];
			LinkedGraphNode<N, L> node2 = nodes[nodeValue2];
			
			node1.AddLink(node2, link);  // Добавляем связь от node1 к node2
		}

		public void Clear()
		{
			nodes.Clear();
		}

		public bool Contains(N nodeValue) => nodes.ContainsKey(nodeValue);

		public void Remove(N nodeValue)
		{
			if (!nodes.TryGetValue(nodeValue, out LinkedGraphNode<N, L> nodeToRemove))
				throw new GraphException("Узел не найден в графе.");

			// Удаляем узел и все связи, указывающие на этот узел
			nodes.Remove(nodeValue);

			foreach (var node in nodes.Values)
			{
				node.RemoveLink(nodeToRemove);
			}
		}

		public int Count => nodes.Count;
		public bool IsEmpty => nodes.Count == 0;
		public IEnumerable<N> Nodes => nodes.Keys;

		public IEnumerator<N> GetEnumerator() => nodes.Keys.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
