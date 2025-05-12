#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int w;

		public Pos(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static Pos Create(int x, int w)
	{
		if (x < 0 || x >= N) return null;
		if (V[x]) return null;

		return new Pos(x, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == B) return p.w;

			int t = T[p.x];
			int m = 1;
			while (0 <= p.x - t || p.x + t < N)
			{
				Push(Create(p.x + t, p.w + 1));
				Push(Create(p.x - t, p.w + 1));
				t = T[p.x] * m++;
			}
		}

		return -1;
	}

	public static int N;
	public static int A, B;
	public static int[] T;
	public static bool[] V;
	public static Queue<Pos> Q;

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		V = new bool[N];
		Q = new Queue<Pos>();
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		S = Console.ReadLine().Split();
		A = int.Parse(S[0]) - 1;
		B = int.Parse(S[1]) - 1;

		Push(Create(A, 0));
		Console.WriteLine(BFS());
	}
}