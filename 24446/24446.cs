#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[] R;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q;

	public static void BFS(int depth)
	{
		List<int> temp = new List<int>();

		while (Q.Count != 0)
		{
			int q = Q.Dequeue();
			R[q - 1] = depth;

			foreach (int l in L[q - 1])
			{
				if (!V[l - 1])
				{
					temp.Add(l);
					V[l - 1] = true;
				}
			}
		}

		if (temp.Count != 0)
		{
			foreach (int t in temp)
			{
				Q.Enqueue(t);
				V[t - 1] = true;
			}

			if (Q.Count != 0) BFS(depth + 1);
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		R = new int[N];
		Array.Fill(R, -1);
		V = new bool[N];
		L = new List<int>[N];
		Q = new Queue<int>();

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

		Q.Enqueue(K);
		V[K - 1] = true;

		BFS(0);

		Console.WriteLine(String.Join("\n", R));
	}
}