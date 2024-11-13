using Directed_Graph.Graphs;

namespace Directed_Graph.Utilities
{
	public static class GraphUtils
	{
		public static bool Exists<N, L>(IGraph<N, L> graph, Predicate<N> predicate)
		{
			foreach (var node in graph.Nodes)
				if (predicate(node)) return true;
			return false;
		}

		public static IGraph<N, L> FindAll<N, L>(IGraph<N, L> graph, Predicate<N> predicate, Func<IGraph<N, L>> graphConstructor)
		{
			var resultGraph = graphConstructor();
			foreach (var node in graph.Nodes)
				if (predicate(node)) resultGraph.AddNode(node);
			return resultGraph;
		}

		public static void ForEach<N, L>(IGraph<N, L> graph, Action<N> action)
		{
			foreach (var node in graph.Nodes) 
				action(node);
		}

		public static bool CheckForAll<N, L>(IGraph<N, L> graph, Predicate<N> predicate)
		{
			foreach (var node in graph.Nodes)
				if (!predicate(node)) return false;
			return true;
		}
	}
}
