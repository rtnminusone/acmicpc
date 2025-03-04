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
		if (V[x, y] || T[x, y] == 1) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static bool BFS()
	{
		while (Q.Count != 0)
		{
			Pos q = Q.Dequeue();

			if (q.x == N - 1) return true;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(q.x + dx[i], q.y + dy[i]));
			}
		}

		return false;
	}

	public static int N;
	public static int M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
			}
		}

		for (int i = 0; i < M; i++)
		{
			if (T[0, i] == 0 && !V[0, i])
			{
				Q.Enqueue(new Pos(0, i));
				V[0, i] = true;

				if (BFS())
				{
					Console.WriteLine("YES");
					return;
				}
			}
		}

		Console.WriteLine("NO");
	}
}