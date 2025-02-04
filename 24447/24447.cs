#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static long C = 1;
	public static long R = 0;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static void BFS(int depth)
	{
		List<int> temp = new List<int>();

		while (Q.Count != 0)
		{
			int q = Q.Dequeue();

			R += depth * C;
			C++;

			foreach (int l in L[q - 1])
			{
				temp.Add(l);
			}
		}

		if (temp.Count != 0)
		{
			foreach (int t in temp)
			{
				if (!V[t - 1])
				{
					V[t - 1] = true;
					Q.Enqueue(t);
				}
			}
		}

		if (Q.Count != 0) BFS(depth + 1);
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		V = new bool[N];
		L = new List<int>[N];

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

		Q.Enqueue(K);
		V[K - 1] = true;

		BFS(0);

		Console.WriteLine(R);
	}
}