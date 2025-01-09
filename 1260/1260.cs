#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static List<int>[] L;
	public static StringBuilder sb1 = new StringBuilder();
	public static StringBuilder sb2 = new StringBuilder();

	public static void DFS(int K, bool[] visited)
	{
		if (visited[K - 1]) return;
		visited[K - 1] = true;
		sb1.Append(K + " ");
		foreach (int f in L[K - 1])
		{
			DFS(f, visited);
		}
	}

	public static void BFS(int K, Queue<int> Q, bool[] visited)
	{
		if (visited[K - 1]) return;
		visited[K - 1] = true;
		sb2.Append(K + " ");
		foreach (int f in L[K - 1])
		{
			Q.Enqueue(f);
		}
		while (Q.Count != 0)
		{
			BFS(Q.Dequeue(), Q, visited);
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		int M = int.Parse(S[1]);
		int V = int.Parse(S[2]);
		L = new List<int>[N];
		Queue<int> Q = new Queue<int>();
		bool[] visited1 = new bool[N];
		bool[] visited2 = new bool[N];

		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]));
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]));
		}

		for (int i = 0; i < N; i++)
		{
			L[i].Sort();
		}

		DFS(V, visited1);
		BFS(V, Q, visited2);

		Console.WriteLine(sb1);
		Console.WriteLine(sb2);
	}
}