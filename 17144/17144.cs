#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
	public static int N;
	public static int M;
	public static int K;
	public static int P1 = -1;
	public static int P2 = -1;
	public static int[,] T;
	public static int[,] W;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void BFS()
	{
		Queue<Pos> temp = new Queue<Pos>();
		W = new int[N, M];

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			int C = 0;

			if (Check(p.x - 1, p.y))
			{
				W[p.x - 1, p.y] += T[p.x, p.y] / 5;
				C++;
			}
			if (Check(p.x + 1, p.y))
			{
				W[p.x + 1, p.y] += T[p.x, p.y] / 5;
				C++;
			}
			if (Check(p.x, p.y - 1))
			{
				W[p.x, p.y - 1] += T[p.x, p.y] / 5;
				C++;
			}
			if (Check(p.x, p.y + 1))
			{
				W[p.x, p.y + 1] += T[p.x, p.y] / 5;
				C++;
			}

			W[p.x, p.y] -= T[p.x, p.y] / 5 * C;
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (W[i, j] != 0) T[i, j] += W[i, j];
			}
		}

		Clean();
		SetQ();
	}

	public static void Clean()
	{
		for (int i = P1 - 1; i > 0; i--)
		{
			T[i, 0] = T[i - 1, 0];
		}
		for (int i = 0; i < M - 1; i++)
		{
			T[0, i] = T[0, i + 1];
		}
		for (int i = 0; i < P1; i++)
		{
			T[i, M - 1] = T[i + 1, M - 1];
		}
		for (int i = M - 1; i > 1; i--)
		{
			T[P1, i] = T[P1, i - 1];
		}

		for (int i = P2 + 1; i < N - 1; i++)
		{
			T[i, 0] = T[i + 1, 0];
		}
		for (int i = 0; i < M - 1; i++)
		{
			T[N - 1, i] = T[N - 1, i + 1];
		}
		for (int i = N - 1; i > P2; i--)
		{
			T[i, M - 1] = T[i - 1, M - 1];
		}
		for (int i = M - 1; i > 1; i--)
		{
			T[P2, i] = T[P2, i - 1];
		}

		T[P1, 1] = 0;
		T[P2, 1] = 0;
	}

	public static void SetQ()
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] != 0 && T[i, j] != -1) Q.Enqueue(new Pos(i, j));
			}
		}
	}

	public static bool Check(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return false;
		if (T[x, y] == -1) return false;

		return true;
	}

	public static int Cal()
	{
		int R = 0;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] != 0 && T[i, j] != -1) R += T[i, j];
			}
		}

		return R;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);

		T = new int[N, M];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] != 0 && T[i, j] != -1) Q.Enqueue(new Pos(i, j));
				if (T[i, j] == -1 && P1 == -1) P1 = i;
				else if (T[i, j] == -1 && P2 == -1) P2 = i;
			}
		}

		while (K != 0)
		{
			BFS();
			K--;
		}

		Console.WriteLine(Cal());
	}
}