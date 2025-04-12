#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int R = int.MinValue;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

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
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[x, y]) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 1) return p.w;

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 0)
				{
					Q = new Queue<Pos>();
					V = new bool[N, M];
					Push(Create(i, j, 0));
					int TR = BFS();
					if (TR > R) R = TR;
				}
			}
		}

		Console.WriteLine(R);
	}
}