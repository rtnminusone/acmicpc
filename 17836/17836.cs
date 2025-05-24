#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public int w;
		public bool s;

		public Pos(int x, int y, int w, bool s)
		{
			this.x = x;
			this.y = y;
			this.w = w;
			this.s = s;
		}
	}

	public static Pos Create(int x, int y, int w, bool s)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (s)
		{
			if (V2[x, y]) return null;
			return new Pos(x, y, w, s);
		}
		else
		{
			if (V[x, y]) return null;
			if (T[x, y] == 2)
			{
				V[x, y] = true;
				return new Pos(x, y, w, true);
			}
			else if (T[x, y] == 0) return new Pos(x, y, w, s);
			else return null;
		}
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		if (pos.s) V2[pos.x, pos.y] = true;
		else V[pos.x, pos.y] = true;

		return true;
	}

	public static string BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.w > K) continue;
			if (p.x == N - 1 && p.y == M - 1) return p.w + "";

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1, p.s));
			}
		}

		return "Fail";
	}

	public static int N, M, K;
	public static int[,] T;
	public static bool[,] V;
	public static bool[,] V2;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		T = new int[N, M];
		V = new bool[N, M];
		V2 = new bool[N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		Push(Create(0, 0, 0, false));
		Console.WriteLine(BFS());
	}
}