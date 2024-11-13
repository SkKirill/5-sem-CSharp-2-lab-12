namespace Directed_Graph.Graphs
{
	public interface IGraph<N, L> : IEnumerable<N>
	{
		void AddNode(N node);
		void AddLink(N node1, N node2, L link);
		void Clear();
		bool Contains(N node);
		void Remove(N node);

		int Count { get; }
		bool IsEmpty { get; }
		IEnumerable<N> Nodes { get; }
	}
}
