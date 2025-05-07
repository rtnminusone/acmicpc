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
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
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
			Pos p = Q.Dequeue();
			int K = T[p.x, p.y];

			if (K == -1) return "HaruHaru";

			Push(Create(p.x + K, p.y));
			Push(Create(p.x, p.y + K));
		}

		return "Hing";
	}

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		V = new bool[N, N];
		Q = new Queue<Pos>();
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}
		Push(Create(0, 0));

		Console.WriteLine(BFS());
	}
}