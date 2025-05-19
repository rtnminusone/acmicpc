#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public int w;
		public int v;

		public Pos(int x, int y, int w, int v)
		{
			this.x = x;
			this.y = y;
			this.w = w;
			this.v = v;
		}
	}

	public static Pos Create(int x, int y, int w, int v)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 1)
		{
			if (v == 0) return new Pos(x, y, w, 1);
			else return null;
		}
		if (V[v, x, y]) return null;

		return new Pos(x, y, w, v);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.v, pos.x, pos.y] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == X && p.y == Y) return p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1, p.v));
			}
		}

		return -1;
	}

	public static int N;
	public static int M;
	public static int X, Y;
	public static int[,] T;
	public static bool[,,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		Q = new Queue<Pos>();

		S = Console.ReadLine().Split();
		int x = int.Parse(S[0]) - 1;
		int y = int.Parse(S[1]) - 1;

		S = Console.ReadLine().Split();
		X = int.Parse(S[0]) - 1;
		Y = int.Parse(S[1]) - 1;

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		V = new bool[2, N, M];
		Push(Create(x, y, 0, 0));

		Console.WriteLine(BFS());
	}
}