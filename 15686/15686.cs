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
	public static int M;
	public static int[,] T;
	public static int[,] R;
	public static bool[,] BV;
	public static Queue<Pos> Q;
	public static Pos[] P;
	public static bool[] DV;
	public static List<Pos> L = new List<Pos>();
	public static List<int> RL = new List<int>();

	public static void DFS(int depth, int start)
	{
		if (depth == M)
		{
			Q = new Queue<Pos>();
			foreach (Pos p in P)
			{
				Q.Enqueue(p);
			}

			R = new int[N, N];
			BV = new bool[N, N];

			BFS(0);

			int S = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					S += R[i, j];
				}
			}
			RL.Add(S);

			return;
		}

		for (int i = start; i < L.Count; i++)
		{
			if (!DV[i])
			{
				DV[i] = true;
				P[depth] = L[i];
				DFS(depth + 1, i);
				DV[i] = false;
			}
		}
	}

	public static void BFS(int distance)
	{
		List<Pos> temp = new List<Pos>();

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 1)
			{
				if (R[p.x, p.y] != 0) R[p.x, p.y] = Math.Min(R[p.x, p.y], distance);
				else R[p.x, p.y] = distance;
			}

			temp.Add(Create(p.x - 1, p.y));
			temp.Add(Create(p.x + 1, p.y));
			temp.Add(Create(p.x, p.y - 1));
			temp.Add(Create(p.x, p.y + 1));
		}

		foreach (Pos p in temp)
		{
			if (p != null)
			{
				Push(p);
			}
		}

		if (Q.Count != 0) BFS(distance + 1);
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= N || BV[x, y]) return null;
		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (BV[pos.x, pos.y]) return false;

		BV[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		T = new int[N, N];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] == 2) L.Add(new Pos(i, j));
			}
		}

		P = new Pos[M];
		DV = new bool[L.Count];

		DFS(0, 0);

		RL.Sort();

		Console.WriteLine(RL[0]);
	}
}