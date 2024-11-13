namespace Directed_Graph.Exceptions
{
	internal class ArgumentNullGraphException : GraphException
	{
		public ArgumentNullGraphException() : base("Ошибка. Попытка передать неверный аргумент в метод!") { }

	}
}
