#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[,] T;
	public static int[][] W;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

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

	public static void BFSW()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (W[p.x][p.y] > 0) W[p.x][p.y] = Math.Min(W[p.x][p.y], p.w);
			else W[p.x][p.y] = p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(CreateW(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}
	}

	public static Pos CreateW(int x, int y, int w)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (T[x, y] == 2 || T[x, y] == 9 || T[x, y] == 1) return null;
		if (V[x, y]) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos p)
	{
		if (p == null) return false;
		if (V[p.x, p.y]) return false;

		V[p.x, p.y] = true;
		Q.Enqueue(p);

		return true;
	}

	public static string BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 9) return p.w + "";

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return "KAKTUS";
	}

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (V[x, y]) return null;
		if (T[x, y] == 1 || T[x, y] == 2) return null;
		if (W[x][y] != -1 && w >= W[x][y]) return null;

		return new Pos(x, y, w);
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		W = new int[N][];
		for (int i = 0; i < N; i++)
		{
			W[i] = new int[M];
			Array.Fill(W[i], -1);
		}
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == 'D') T[i, j] = 9;
				else if (S[0][j] == 'S') T[i, j] = 8;
				else if (S[0][j] == 'X') T[i, j] = 2;
				else if (S[0][j] == '.') T[i, j] = 0;
				else if (S[0][j] == '*') T[i, j] = 1;
			}
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 1)
				{
					V = new bool[N, M];
					V[i, j] = true;
					Q.Enqueue(new Pos(i, j, 0));
					BFSW();
				}
			}
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 8)
				{
					V = new bool[N, M];
					Q.Enqueue(new Pos(i, j, 0));
					V[i, j] = true;
					Console.WriteLine(BFS());
					break;
				}
			}
		}
	}
}