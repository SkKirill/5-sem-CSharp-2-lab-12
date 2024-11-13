namespace Directed_Graph.Exceptions
{
	public class UnmutebaleGraphException : GraphException
	{
		public UnmutebaleGraphException() : base("Ошибка. Попытка изменить неизменяемый объект!") { }
	}
}
