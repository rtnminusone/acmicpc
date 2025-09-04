#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N, M, K, G;
	public static List<int>[] L;
	public static bool[] V;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static List<int> R = new List<int>();

	public class Pos
	{
		public int x;
		public int w;

		public Pos(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.w == K)
			{
				R.Add(p.x);
				continue;
			}

			foreach (int l in L[p.x - 1])
			{
				if (!V[l - 1])
				{
					Q.Enqueue(new Pos(l, p.w + 1));
					V[l - 1] = true;
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		G = int.Parse(S[3]);
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
		}

		Q.Enqueue(new Pos(G, 0));
		V[G - 1] = true;

		BFS();
		R.Sort();

		if (R.Count == 0) Console.WriteLine(-1);
		else
		{
			foreach (int r in R)
			{
				Console.WriteLine(r);
			}
		}
	}
}