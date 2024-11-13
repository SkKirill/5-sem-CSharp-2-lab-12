using Directed_Graph.Exceptions;
using System.Collections;

namespace Directed_Graph.Graphs
{
	public class UnmutableGraph<N, L> : IGraph<N, L>
	{
		private readonly IGraph<N, L> innerGraph;

		public UnmutableGraph(IGraph<N, L> graph) => innerGraph = graph ?? throw new ArgumentNullGraphException();

		public void AddNode(N node) => throw new UnmutebaleGraphException();
		public void AddLink(N node1, N node2, L link) => throw new UnmutebaleGraphException();
		public void Clear() => throw new UnmutebaleGraphException();
		public bool Contains(N node) => innerGraph.Contains(node);
		public void Remove(N node) => throw new UnmutebaleGraphException();

		public int Count => innerGraph.Count;
		public bool IsEmpty => innerGraph.IsEmpty;
		public IEnumerable<N> Nodes => innerGraph.Nodes;

		public IEnumerator<N> GetEnumerator() => innerGraph.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
