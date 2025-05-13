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

	public static Pos Create(int x, int y, int org)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[x, y]) return null;
		if (T[x, y] != org) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static bool BFS(int org, int upd)
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			K[p.x, p.y] = upd;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], org));
			}
		}

		return Check(); 
	}

	public static void ArrayCopy()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				K[i, j] = T[i, j];
			}
		}
	}

	public static bool Check()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (K[i, j] != U[i, j]) return false;
			}
		}

		return true;
	}

	public static int N, M;
	public static int[,] T, U, K;
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
		U = new int[N, M];
		K = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				K[i, j] = T[i, j];
			}
		}
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				U[i, j] = int.Parse(S[j]);
			}
		}
		string Ans = "NO";
		if (Check()) Ans = "YES";
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] != U[i, j])
				{
					ArrayCopy();
					Push(Create(i, j, T[i, j]));
					if (BFS(T[i, j], U[i, j]))
					{
						Ans = "YES";
						i = N;
						break;
					}
				}
			}
		}

		Console.WriteLine(Ans);
	}
}