#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int M;
	public static int[] T;
	public static int[] R;
	public static Dictionary<string, int> D = new Dictionary<string, int>();

	public static void DFS(int depth)
	{
		if (depth == M)
		{
			D[String.Join(" ", R)] = 1;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			R[depth] = T[i];
			DFS(depth + 1);
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N];
		R = new int[M];

		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		Array.Sort(T);

		DFS(0);

		foreach (var d in D)
		{
			sb.AppendLine(d.Key);
		}

		Console.WriteLine(sb);
	}
}