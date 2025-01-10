#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;

	public static void DFS(int start, int current, int[, ] K, bool[] V, int[, ] A)
	{
		for (int i = 0; i < N; i++)
		{
			if (K[current, i] == 1 && !V[i])
			{
				V[i] = true;
				A[start, i] = 1;
				DFS(start, i, K, V, A);
			}
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		N = int.Parse(Console.ReadLine());
		int[, ] K = new int[N, N];
		int[, ] A = new int[N, N];
		bool[] V = new bool[N];

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				K[i, j] = int.Parse(S[j]);
			}
		}

		for (int i = 0; i < N; i++)
		{
			Array.Fill(V, false);
			DFS(i, i, K, V, A);
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				sb.Append(A[i, j] + " ");
			}
			sb.AppendLine("");
		}

		Console.WriteLine(sb);
	}
}