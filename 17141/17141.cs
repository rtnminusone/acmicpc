#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public int w;

		public Pos(int x, int y, int w)
		{
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static void INIT(Pos[] P)
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (T[i, j] == 1) K[i, j] = 0;
				else K[i, j] = -1;
			}
		}

		foreach (Pos p in P)
		{
			K[p.x, p.y] = 0;
		}
	}

	public static bool CHECK()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (K[i, j] < 0) return false;
			}
		}

		return true;
	}

	public static void DFS(int depth, int start, Pos[] comb)
	{
		if (depth == M)
		{
			V = new bool[N, N];
			Q = new Queue<Pos>();
			foreach (Pos p in comb)
			{
				Push(p);
			}
			INIT(comb);
			int r = BFS();
			if (r < R && CHECK()) R = r;
			return;
		}

		for (int i = start; i < L.Count; i++)
		{
			if (!VD[i])
			{
				VD[i] = true;
				comb[depth] = new Pos(L[i].x, L[i].y, 0);
				DFS(depth + 1, i + 1, comb);
				VD[i] = false;
			}
		}
	}

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (V[x, y] || T[x, y] == 1) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static int BFS()
	{
		int r = int.MinValue;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (r < p.w) r = p.w;
			K[p.x, p.y] = p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return r;
	}

	public static int N, M;
	public static int R = int.MaxValue;
	public static int[,] T, K;
	public static bool[] VD;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static List<Pos> L = new List<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, N];
		K = new int[N, N];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] == 2) L.Add(new Pos(i, j, 0));
			}
		}
		VD = new bool[L.Count];

		DFS(0, 0, new Pos[M]);

		if (R != int.MaxValue) Console.WriteLine(R);
		else Console.WriteLine(-1);
	}
}