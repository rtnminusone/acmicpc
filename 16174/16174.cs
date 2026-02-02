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
		if (x < 0 || y < 0 || x >= N || y >= N) return null;
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

	public static bool BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1 && p.y == N - 1) return true;

			Push(Create(p.x + T[p.x, p.y], p.y));
			Push(Create(p.x, p.y + T[p.x, p.y]));
		}

		return false;
	}

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		V = new bool[N, N];

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		Push(Create(0, 0));

		if (BFS()) Console.WriteLine("HaruHaru");
		else Console.WriteLine("Hing");
	}
}