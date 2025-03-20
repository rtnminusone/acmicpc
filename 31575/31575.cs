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
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { 1, 0 };
	public static int[] dy = { 0, 1 };

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 0) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static string BFS()
	{
		while (Q.Count != 0)
		{
			Pos q = Q.Dequeue();

			if (q.x == N - 1 && q.y == M - 1) return "Yes";

			for (int i = 0; i < 2; i++)
			{
				Push(Create(q.x + dx[i], q.y + dy[i]));
			}
		}

		return "No";
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		T = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		Push(Create(0, 0));

		Console.WriteLine(BFS());
	}
}