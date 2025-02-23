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

	public static int N;
	public static int M;
	public static int R = int.MinValue;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void BFS()
	{
		int r = 0;

		while (Q.Count != 0)
		{
			Pos q = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(q.x + dx[i], q.y + dy[i]));
			}

			r++;
		}

		if (r > R) R = r;
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (T[x, y] != 1) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		if (V[pos.x, pos.y]) return false;

		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);
		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < K; i++)
		{
			S = Console.ReadLine().Split();
			T[int.Parse(S[0]) - 1, int.Parse(S[1]) - 1] = 1;
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 1 && !V[i, j])
				{
					Push(Create(i, j));
					BFS();
				}
			}
		}

		Console.WriteLine(R);
	}
}