#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int R = 0;
	public static int[,] T;
	public static int[,] W;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

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

	public static Pos Create(Pos p, int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (T[x, y] < 1)
		{
			W[p.x, p.y]++;
			return null;
		}
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		if (V[pos.x, pos.y]) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p, p.x + dx[i], p.y + dy[i]));
			}
		}
	}

	public static void Cal()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (W[i, j] != 0)
				{
					T[i, j] -= W[i, j];
					if (T[i, j] < 0) T[i, j] = 0;
				}
			}
		}
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

		while (true)
		{
			int K = 0;
			W = new int[N, M];
			V = new bool[N, M];
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] > 0 && !V[i, j])
					{
						Q.Enqueue(new Pos(i, j));
						V[i, j] = true;
						BFS();
						K++;
					}
				}
			}
			if (K == 0)
			{
				R = 0;
				break;
			}
			if (K > 1) break;
			Cal();
			R++;
		}

		Console.WriteLine(R);
	}
}