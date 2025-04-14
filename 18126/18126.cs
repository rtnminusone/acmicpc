#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public long x;
		public long w;

		public Pos(long x, long w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static bool Push(long x, long w)
	{
		if (V[x]) return false;

		Q.Enqueue(new Pos(x, w));
		V[x] = true;

		return true;
	}

	public static long BFS()
	{
		long R = long.MinValue;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.w > R) R = p.w;

			for (long i = 0; i < N; i++)
			{
				if (T[p.x, i] != 0)
				{
					Push(i, p.w + T[p.x, i]);
				}
			}
		}

		return R;
	}

	public static long N;
	public static long[,] T;
	public static bool[] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		N = long.Parse(Console.ReadLine());
		T = new long[N, N];
		V = new bool[N];

		for (long i = 0; i < N - 1; i++)
		{
			string[] S = Console.ReadLine().Split();
			T[long.Parse(S[0]) - 1, long.Parse(S[1]) - 1] = long.Parse(S[2]);
			T[long.Parse(S[1]) - 1, long.Parse(S[0]) - 1] = long.Parse(S[2]);
		}

		Q.Enqueue(new Pos(0, 0));
		V[0] = true;
		Console.WriteLine(BFS());
	}
}