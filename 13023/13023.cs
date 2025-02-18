#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int R = 0;
	public static bool[] V;
	public static List<int>[] L;

	public static void DFS(int depth, int C)
	{
		if (depth == 5)
		{
			Console.WriteLine(1);
			Environment.Exit(0);
		}

		foreach (int l in L[C])
		{
			if (!V[l])
			{
				V[l] = true;
				DFS(depth + 1, l);
				V[l] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];

		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0])].Add(int.Parse(S[1]));
			L[int.Parse(S[1])].Add(int.Parse(S[0]));
		}

		for (int i = 0; i < N; i++)
		{
			V[i] = true;
			DFS(1, i);
			V[i] = false;
		}

		Console.WriteLine(0);
	}
}