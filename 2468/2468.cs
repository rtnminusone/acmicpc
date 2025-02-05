#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N;
	public static int R = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static List<int> L = new List<int>();

	public static void BFS(int goal)
	{
		while (Q.Count != 0)
		{
			Pos q = Q.Dequeue();

			Push(Create(q.x - 1, q.y), goal);
			Push(Create(q.x + 1, q.y), goal);
			Push(Create(q.x, q.y - 1), goal);
			Push(Create(q.x, q.y + 1), goal);
		}

		R++;
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= N || V[x, y]) return null;
		return new Pos(x, y);
	}

	public static bool Push(Pos pos, int goal)
	{
		if (pos == null || T[pos.x, pos.y] <= goal) return false;

		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		int Max = int.MinValue;

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (Max < T[i, j]) Max = T[i, j];
			}
		}

		for (int i = 0; i < Max; i++)
		{
			V = new bool[N, N];
			Q = new Queue<Pos>();
			R = 0;

			for (int x = 0; x < N; x++)
			{
				for (int y = 0; y < N; y++)
				{
					if (V[x, y]) continue;
					if (Push(Create(x, y), i)) BFS(i);
				}
			}

			L.Add(R);
		}

		L.Sort();

		Console.WriteLine(L[L.Count - 1]);
	}
}