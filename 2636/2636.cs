#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[,] T;
	public static int[,] W;
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

			if (T[p.x, p.y] == 1)
			{
				W[p.x, p.y] = 1;
				R++;
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					Push(Create(p.x + dx[i], p.y + dy[i]));
				}
			}
		}

		return R;
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
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

	public static void Cal()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (W[i, j] != 0) T[i, j] -= W[i, j];
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

		int R = 0;
		int P = 0;
		while (true)
		{
			P = 0;
			V = new bool[N, M];
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] == 1 && !V[i, j])
					{
						Q.Enqueue(new Pos(i, j));
						V[i, j] = true;
						P += BFSC();
					}
				}
			}
			L.Add(P);
			int K = 0;
			W = new int[N, M];
			V = new bool[N, M];
			for (int i = 0; i < N; i++)
			{
				if (!V[i, 0])
				{
					Q.Enqueue(new Pos(i, 0));
					V[i, 0] = true;
					K += BFS();
				}
				if (!V[i, M - 1])
				{
					Q.Enqueue(new Pos(i, M - 1));
					V[i, M - 1] = true;
					K += BFS();
				}
			}
			for (int i = 0; i < M; i++)
			{
				if (!V[0, i])
				{
					Q.Enqueue(new Pos(0, i));
					V[0, i] = true;
					K += BFS();
				}
				if (!V[N - 1, i])
				{
					Q.Enqueue(new Pos(N - 1, i));
					V[N - 1, i] = true;
					K += BFS();
				}
			}
			if (K == 0) break;
			Cal();
			R++;
		}

		Console.WriteLine(R);
		if (L.Count == 0 || L.Count == 1) Console.WriteLine(0);
		else Console.WriteLine(L[L.Count - 2]);
	}

	public static int BFSC()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 1)
			{
				R++;
				for (int i = 0; i < 4; i++)
				{
					Push(Create(p.x + dx[i], p.y + dy[i]));
				}
			}
		}

		return R;
	}
}