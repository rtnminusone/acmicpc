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
		if (T[x, y] == 0) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos p)
	{
		if (p == null) return false;

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

	public static int N, M;
	public static int[,] T, RGB;
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
		RGB = new int[N, M];
		Q = new Queue<Pos>();
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M * 3; j += 3)
			{
				RGB[i, j / 3] = (int.Parse(S[j]) + int.Parse(S[j + 1]) + int.Parse(S[j + 2])) / 3;
			}
		}
		int t = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				T[i, j] = RGB[i, j] >= t ? 1 : 0;
			}
		}

		int R = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 1)
				{
					if (Push(Create(i, j)))
					{
						BFS();
						R++;
					}
				}
			}
		}

		Console.WriteLine(R);
	}
}