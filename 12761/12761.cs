#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int MAX = 100000;
	public static int A, B, N, M;
	public static bool[] V = new bool[MAX + 1];
	public static Queue<Pos> Q = new Queue<Pos>();

	public class Pos
	{
		public int q;
		public int w;

		public Pos(int q, int w)
		{
			this.q = q;
			this.w = w;
		}
	}

	public static Pos Create(int q, int w)
	{
		if (q < 0 || q > MAX) return null;
		if (V[q]) return null;

		return new Pos(q, w);
	}

	public static bool Push(Pos p)
	{
		if (p == null) return false;

		Q.Enqueue(p);
		V[p.q] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.q == M) return p.w;

			Push(Create(p.q - 1, p.w + 1));
			Push(Create(p.q + 1, p.w + 1));
			Push(Create(p.q - A, p.w + 1));
			Push(Create(p.q + A, p.w + 1));
			Push(Create(p.q - B, p.w + 1));
			Push(Create(p.q - B, p.w + 1));
			Push(Create(p.q + B, p.w + 1));
			Push(Create(p.q * A, p.w + 1));
			Push(Create(p.q * B, p.w + 1));
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		A = int.Parse(S[0]);
		B = int.Parse(S[1]);
		N = int.Parse(S[2]);
		M = int.Parse(S[3]);

		Push(Create(N, 0));

		Console.WriteLine(BFS());
	}
}