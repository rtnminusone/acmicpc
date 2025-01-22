#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int H;
	public static int[,,] T;
	public static int[,,] R;
	public static bool[,,] B;
	public static Queue<Pos> Q = new Queue<Pos>();

	public class Pos
	{
		public int h { get; set; }
		public int n { get; set; }
		public int m { get; set; }

		public Pos(int h, int n, int m)
		{
			this.h = h;
			this.n = n;
			this.m = m;
		}
	}

	public static Pos Create(int h, int n, int m)
	{
		if (h < 0 || n < 0 || m < 0 || h >= H || n >= N || m >= M) return null;
		if (B[h, n, m]) return null;
		return new Pos(h, n, m);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		B[pos.h, pos.n, pos.m] = true;
		Q.Enqueue(pos);
		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		M = int.Parse(S[0]);
		N = int.Parse(S[1]);
		H = int.Parse(S[2]);
		T = new int[H, N, M];
		R = new int[H, N, M];
		B = new bool[H, N, M];

		for (int i = 0; i < H; i++)
		{
			for (int j = 0; j < N; j++)
			{
				S = Console.ReadLine().Split();
				for (int k = 0; k < M; k++)
				{
					T[i, j, k] = int.Parse(S[k]);
					if (T[i, j, k] == -1)
					{
						B[i, j, k] = true;
						R[i, j, k] = -1;
					}
					else if (T[i, j, k] == 1)
					{
						Push(Create(i, j, k));
						R[i, j, k] = 1;
					}
				}
			}
		}

		while (Q.Count != 0)
		{
			var P = Q.Dequeue();
			if (Push(Create(P.h - 1, P.n, P.m))) R[P.h - 1, P.n, P.m] = R[P.h, P.n, P.m] + 1;
			if (Push(Create(P.h + 1, P.n, P.m))) R[P.h + 1, P.n, P.m] = R[P.h, P.n, P.m] + 1;
			if (Push(Create(P.h, P.n - 1, P.m))) R[P.h, P.n - 1, P.m] = R[P.h, P.n, P.m] + 1;
			if (Push(Create(P.h, P.n + 1, P.m))) R[P.h, P.n + 1, P.m] = R[P.h, P.n, P.m] + 1;
			if (Push(Create(P.h, P.n, P.m - 1))) R[P.h, P.n, P.m - 1] = R[P.h, P.n, P.m] + 1;
			if (Push(Create(P.h, P.n, P.m + 1))) R[P.h, P.n, P.m + 1] = R[P.h, P.n, P.m] + 1;
		}

		int A = int.MinValue;

		for (int i = 0; i < H; i++)
		{
			for (int j = 0; j < N; j++)
			{
				for (int k = 0; k < M; k++)
				{
					if (R[i, j, k] == 0)
					{
						Console.WriteLine(-1);
						Environment.Exit(0);
					}
					if (R[i, j, k] > A) A = R[i, j, k];
				}
			}
		}

		Console.WriteLine(A - 1);
	}
}