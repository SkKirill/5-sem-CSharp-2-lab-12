### Скоморохов Кирилл | 8 (900) 988-75-37 | T-Банк | tg = @sk_kiriII | vk = sk_kirill | VisualStudio2022 | C#

> **1500₽**

# Задача 11 

**Ориентированный граф**  
> Разработать обобщенный класс `Graph<N, L>` - класс для описания ориентированных графов 
> (N - тип вершин; L - тип связей).
``` CSharp
IGraph <N,L>: IEnumerable<N,L>
```
> \- базовый интерфейс для всех ориентированных графов;

**Методы:**
- void AddNode(N node);
- void AddLink(N node1, N node2);
- void Clear();
- bool Contains(N node);
- void Remove(N node);

**Свойства:**
- int Count;
- bool isEmpty;
- IEnumerable<N> nodes;

`GraphException` - класс, описывающий исключения, которые могут происходить в ходе работы c ориентированным графом (также можно 
написать ряд наследников от GraphException);

`ArrayGraph <N, L>: IGraph<N, L>` - класс ориентированного графа на основе массива;
`LinkedGraph <N, L>: IGraph<N, L>` - класс ориентированногографа на основе связного списка;
`UnmutableGraph<N, L>: IGraph<N, L>` - класс неизменяющегося ориентированного графа, является оберткой над любым существующим графом 
(должен кидаться исключениями на вызов любого метода, изменяющего граф);

`GraphUtils` - класс различных операций над ориентированным графом; 

**Методы:**
- static bool Exists<N>(IGraph<N, L>, CheckDelegate<N, L>);
- static IGraph<N, L> FindAll<N, L>(IGraph<N, L>, CheckDelegate<N, L>, GraphConstructorDelegate<N, L>);
- static void ForEach(IGraph<N, L>, ActionDelegate<N, L>);
- static bool CheckForAll<N, L>(IGraph<N, L>, CheckDelegate<N, L>);


**Cвoйcтвa:**
- static readonly GraphConstructorDelegate<N, L> ArrayGraphConstructor;
- static readonly GraphConstructorDelegate<N, L> LinkedGraphConstructor;

> Класс должен поддерживать базовые алгоритмы на графах (обход графа в глубину, обход графа в ширину, поиск кратчайшего пути и т.п.)
> Также необходимо разработать серию примеров, демонстрирующих основные аспекты работы c данной библиотекой ориентированных графов.

# Структура проекта

```
Directed-Graph/
├── Graphs/
│   ├── ArrayGraph.cs
│   ├── LinkedGraphNode.cs
│   ├── LinkedGraph.cs
│   └── UnmutableGraph.cs
├── Exceptions/
│   ├── GraphException.cs
│   ├── NullReferencesGraphException.cs
│   ├── .cs
│   ├── .cs
│   └── .cs
├── Utilites/
│   ├── GraphUtils.cs
│   └── TestClass.cs
└── TestProgram.cs
```

# Примечания 