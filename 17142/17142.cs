#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (V[x, y]) return null;
		if (T[x, y] == 1) return null;

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
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 0) b--;

			if (b == 0) return p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return int.MaxValue;
	}

	public static void DFS(int depth, int start, Pos[] sel)
	{
		if (depth == M)
		{
			Q = new Queue<Pos>();
			V = new bool[N, N];
			b = B;

			for (int i = 0; i < M; i++)
			{
				Push(sel[i]);
			}
			L.Add(BFS());
			return;
		}

		for (int i = start; i < D.Count; i++)
		{
			if (!VD[i])
			{
				VD[i] = true;
				sel[depth] = D[i];
				DFS(depth + 1, i, sel);
				VD[i] = false;
			}
		}
	}

	public static int N;
	public static int M;
	public static int B = 0;
	public static int b;
	public static int[,] T;
	public static bool[,] V;
	public static bool[] VD;
	public static Queue<Pos> Q;
	public static List<Pos> D = new List<Pos>();
	public static List<int> L = new List<int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

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
				if (T[i, j] == 2) D.Add(new Pos(i, j, 0));
				else if (T[i, j] == 0) B++;
			}
		}

		VD = new bool[D.Count];
		DFS(0, 0, new Pos[M]);
		L.Sort();

		if (L[0] == int.MaxValue) Console.WriteLine(-1);
		else Console.WriteLine(L[0]);
	}
}