#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }
		public int z { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.z = 0;
		}

		public Pos(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}

	public static int N;
	public static int[,] T;
	public static int H = 2;
	public static int X = 0;
	public static int[,] W;
	public static bool[,] V;
	public static bool[,] B;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int BFS()
	{
		W = new int[N, N];
		V = new bool[N, N];
		B = new bool[N, N];
		int C = int.MaxValue;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			W[p.x, p.y] = p.z;
			if (T[p.x, p.y] != 0 && T[p.x, p.y] < H)
			{
				B[p.x, p.y] = true;
				if (p.z < C) C = p.z;
			}

			Push(Create(p.x - 1, p.y, p.z + 1));
			Push(Create(p.x + 1, p.y, p.z + 1));
			Push(Create(p.x, p.y - 1, p.z + 1));
			Push(Create(p.x, p.y + 1, p.z + 1));
		}

		if (C == int.MaxValue) return 0;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (B[i, j] && W[i, j] == C)
				{
					T[i, j] = 0;
					if (X + 1 == H)
					{
						H++;
						X = 0;
					}
					else X++;

					Q.Enqueue(new Pos(i, j));

					return W[i, j];
				}
			}
		}

		return 0;
	}

	public static Pos Create(int x, int y, int z)
	{
		if (x < 0 || y < 0 || x >= N || y >= N || V[x, y]) return null;
		if (H < T[x, y]) return null;

		return new Pos(x, y, z);
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
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		int Sum = 0;

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] == 9)
				{
					T[i, j] = 0;
					Q.Enqueue(new Pos(i, j));
				}
			}
		}

		while (Q.Count != 0)
		{
			Sum += BFS();
		}

		Console.WriteLine(Sum);
	}
}