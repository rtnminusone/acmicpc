#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[,] T;
	public static bool[,] V;
	public static List<int> L = new List<int>();
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

	public static int BFS()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}

			R++;
		}

		return R;
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (T[x, y] == 0) return null;
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

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		T = new int[N, M];
		V = new bool[N, M];

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
				if (T[i, j] == 1 && !V[i, j])
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
					L.Add(BFS());
				}
			}
		}

		L.Sort();

		Console.WriteLine(L.Count);
		if (L.Count == 0) Console.WriteLine(0);
		else Console.WriteLine(L[L.Count - 1]);
	}
}