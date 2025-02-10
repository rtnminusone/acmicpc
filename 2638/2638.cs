#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
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

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (T[x, y] == 1)
		{
			W[x, y]++;
			return null;
		}
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos p)
	{
		if (p == null) return false;
		if (V[p.x, p.y]) return false;

		Q.Enqueue(p);
		V[p.x, p.y] = true;

		return true;
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}
	}

	public static bool Cal()
	{
		int R = 0;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (W[i, j] > 1)
				{
					T[i, j] = 0;
					R++;
				}
			}
		}

		return R == 0 ? true : false;
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

		int P = 0;
		while (true)
		{
			int K = 0;
			W = new int[N, M];
			V = new bool[N, M];
			for (int i = 0; i < N; i++)
			{
				if (T[i, 0] == 0 && !V[i, 0])
				{
					Q.Enqueue(new Pos(i, 0));
					V[i, 0] = true;
					BFS();
					K++;
				}
				if (T[i, M - 1] == 0 && !V[i, M - 1])
				{
					Q.Enqueue(new Pos(i, M - 1));
					V[i, M - 1] = true;
					BFS();
					K++;
				}
			}
			for (int i = 0; i < M; i++)
			{
				if (T[0, i] == 0 && !V[0, i])
				{
					Q.Enqueue(new Pos(0, i));
					V[0, i] = true;
					BFS();
					K++;
				}
				if (T[N - 1, i] == 0 && !V[N - 1, i])
				{
					Q.Enqueue(new Pos(N - 1, i));
					V[N - 1, i] = true;
					BFS();
					K++;
				}
			}
			if (K == 0) break;
			if (Cal()) break;
			P++;
		}

		Console.WriteLine(P);
	}
}