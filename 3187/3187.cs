#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[x, y]) return null;
		if (T[x, y] == -1) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static void BFS()
	{
		int s = 0;
		int w = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 1) s++;
			else if (T[p.x, p.y] == 2) w++;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}

		if (s > w) R1 += s;
		else R2 += w;
	}

	public static int N;
	public static int M;
	public static int R1 = 0;
	public static int R2 = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == '.') T[i, j] = 0;
				else if (S[0][j] == 'k') T[i, j] = 1;
				else if (S[0][j] == 'v') T[i, j] = 2;
				else T[i, j] = -1;
			}
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				Push(Create(i, j));
				BFS();
			}
		}

		Console.WriteLine(R1 + " " + R2);
	}
}