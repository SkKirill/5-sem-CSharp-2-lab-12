using Directed_Graph.Graphs;
using Directed_Graph.Utilities;

internal class TestProgram
{
	private static void Main(string[] args)
	{
		Console.InputEncoding = System.Text.Encoding.UTF8;
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		// Тест ArrayGraph
		var arrayGraph = new ArrayGraph<string, int>();
		RunTests(arrayGraph);

		// Тест LinkedGraph
		var linkedGraph = new LinkedGraph<string, int>();
		RunTests(linkedGraph);

		var unmutebleGraph = new UnmutableGraph<string, int>(linkedGraph);
		RunTests(unmutebleGraph);
		
		TestUtils();

		Console.WriteLine("Тесты завершены.");

	}

	private static void TestUtils()
	{
		// Тесты GraphUtils (сначала создадим тестовый граф и выполним действия)
		Console.WriteLine("---------------------------------------------------------------------------------------");
		Console.WriteLine("Тесты для GraphUtils:");

		var testGraph = new ArrayGraph<string, int>();
		testGraph.AddNode("X");
		testGraph.AddNode("Y");
		testGraph.AddLink("X", "Y", 1);

		// Пример использования методов из GraphUtils (допустим, методы реализованы)
		Console.WriteLine("Применяем GraphUtils.Exists...");
		bool exists = GraphUtils.Exists(testGraph, node => node == "X");
		Console.WriteLine("Существует ли узел 'X'? " + exists);

		Console.WriteLine("Применяем GraphUtils.ForEach...");
		GraphUtils.ForEach(testGraph, item => Console.WriteLine($"Узел: {item}"));
	}

	private static void RunTests(IGraph<string, int> graph)
	{
		Console.WriteLine("---------------------------------------------------------------------------------------");
		Console.WriteLine("Тестируем граф: " + graph.GetType().Name);

		try
		{
			// Добавление узлов
			Console.WriteLine("Добавление узлов...");
			graph.AddNode("A");
			graph.AddNode("B");
			graph.AddNode("C");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			Console.WriteLine("Узлы в графе:");
			foreach (var node in graph.Nodes)
			{
				Console.WriteLine(" - " + node);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			// Проверка метода Contains
			Console.WriteLine("Содержит ли граф узел 'A'? " + graph.Contains("A"));
			Console.WriteLine("Содержит ли граф узел 'D'? " + graph.Contains("D"));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			// Добавление направленных связей
			Console.WriteLine("Добавление связей...");
			graph.AddLink("A", "B", 5);
			graph.AddLink("B", "C", 10);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			// Проверка свойства Count и IsEmpty
			Console.WriteLine("Количество узлов в графе: " + graph.Count);
			Console.WriteLine("Пустой ли граф? " + graph.IsEmpty);

			// Попытка добавить узел, который уже существует (ожидается исключение)
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			graph.AddNode("A");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ошибка при добавлении узла 'A': " + ex.Message);
		}
		try
		{
			// Удаление узла и проверка
			Console.WriteLine("Удаляем узел 'C'...");
			graph.Remove("C");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		try
		{
			Console.WriteLine("Узлы после удаления:");
			foreach (var node in graph.Nodes)
			{
				Console.WriteLine(" - " + node);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}


		Console.WriteLine("Тесты для графа завершены.\n");
	}
}