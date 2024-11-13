namespace Directed_Graph.Graphs
{
	public class LinkedGraphNode<N, L>
	{
		public N Value { get; }
		public Dictionary<LinkedGraphNode<N, L>, L> Links { get; } // Связи с другими узлами

		public LinkedGraphNode(N value)
		{
			Value = value;
			Links = new Dictionary<LinkedGraphNode<N, L>, L>();
		}

		public void AddLink(LinkedGraphNode<N, L> targetNode, L link)
		{
			Links[targetNode] = link;  // Добавляем или обновляем ссылку на целевой узел
		}

		public void RemoveLink(LinkedGraphNode<N, L> targetNode)
		{
			Links.Remove(targetNode); // Удаление ссылки на целевой узел
		}
	}
}
