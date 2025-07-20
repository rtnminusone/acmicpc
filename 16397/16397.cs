#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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
		if (x < 0 || x > 99999) return null;
		if (V[x]) return null;

		return new Pos(x, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		V[pos.x] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static int PushB(int n)
	{
		n *= 2;

		if (n > 99999) return -1;

		if (n / 10000 != 0) return n - 10000;
		if (n / 1000 != 0) return n - 1000;
		if (n / 100 != 0) return n - 100;
		if (n / 10 != 0) return n - 10;
		if (n != 0) return n - 1;
		return 0;
	}

	public static string BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == G) return p.w + "";

			if (p.w < T)
			{
				Push(Create(p.x + 1, p.w + 1));
				Push(Create(PushB(p.x), p.w + 1));
			}
		}

		return "ANG";
	}

	public static int N, T, G;
	public static bool[] V = new bool[100000];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		T = int.Parse(S[1]);
		G = int.Parse(S[2]);
		Push(Create(N, 0));

		Console.WriteLine(BFS());
	}
}