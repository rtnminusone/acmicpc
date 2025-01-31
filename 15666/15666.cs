#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int M;
	public static List<int> L = new List<int>();
	public static StringBuilder sb = new StringBuilder();

	public static void DFS(int depth, int start, int[] R)
	{
		if (depth == M)
		{
			sb.AppendLine(String.Join(" ", R));
			return;
		}

		for (int i = start; i < L.Count; i++)
		{
			R[depth] = L[i];
			DFS(depth + 1, i, R);
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			int l = int.Parse(S[i]);
			if (!L.Contains(l)) L.Add(l);
		}
		L.Sort();

		DFS(0, 0, new int[M]);

		Console.WriteLine(sb);
	}
}