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

	public static Pos Create(int flag, int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (flag != T[x, y]) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static int BFS(int flag)
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(flag, p.x + dx[i], p.y + dy[i]));
			}

			R++;
		}

		return R * R;
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		M = int.Parse(S[0]);
		N = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == 'W') T[i, j] = 0;
				else T[i, j] = 1;
			}
		}

		int[] R = new int[2];

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (Push(Create(T[i, j], i, j))) R[T[i, j]] += BFS(T[i, j]);
			}
		}

		Console.WriteLine(R[0] + " " + R[1]);
	}
}