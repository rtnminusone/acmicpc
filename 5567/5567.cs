#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[] R;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			int q = Q.Dequeue();

			foreach (int l in L[q - 1])
			{
				R[l - 1] = 1;
			}
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		M = int.Parse(Console.ReadLine());
		R = new int[N];
		L = new List<int>[N];

		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		for (int i = 0; i < M; i++)
		{
			string[] S = Console.ReadLine().Split();
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]));
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]));
		}

		Q.Enqueue(1);
		foreach (int l in L[0])
		{
			Q.Enqueue(l);
		}
		BFS();

		int result = 0;
		for (int i = 1; i < N; i++)
		{
			result += R[i];
		}

		Console.WriteLine(result);
	}
}