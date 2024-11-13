namespace Directed_Graph.Exceptions
{
	public class NullReferenceGraphException : GraphException
	{
		public NullReferenceGraphException() : base("Ошибка. Попытка обратиться к несущестующему объекту!") { }
	}
}
