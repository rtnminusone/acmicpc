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
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M || V[x, y]) return null;
		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);
		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		M = int.Parse(S[0]);
		N = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				if (S[j] == "1")
				{
					Push(Create(i, j));
					T[i, j] = 1;
				}
				else if (S[j] == "-1")
				{
					V[i, j] = true;
					T[i, j] = int.MinValue;
				}
			}
		}

		int[,] C = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

		while (Q.Count != 0)
		{
			Pos pos = Q.Dequeue();
			for (int i = 0; i < 4; i++)
			{
				if (Push(Create(pos.x + C[i, 0], pos.y + C[i, 1]))) T[pos.x + C[i, 0], pos.y + C[i, 1]] = T[pos.x, pos.y] + 1;
			}
		}

		int Max = int.MinValue;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 0)
				{
					Console.WriteLine(-1);
					Environment.Exit(0);
				}
				if (T[i, j] > Max) Max = T[i, j];
			}
		}
		Console.WriteLine(Max - 1);
	}
}