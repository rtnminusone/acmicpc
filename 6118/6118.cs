#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
//using System.Linq;

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

		public Pos(Pos p)
		{
			this.x = p.x;
			this.w = p.w;
		}
	}

	public static Pos Create(int x, int w)
	{
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

	public static string BFS()
	{
		List<Pos> R = new List<Pos>();

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (R.Count == 0) R.Add(p);
			else
			{
				if (R[0].w < p.w) R = new List<Pos>();
				if (R.Count == 0 || R[0].w <= p.w) R.Add(p);
			}

			foreach (int l in L[p.x])
			{
				Push(Create(l, p.w + 1));
			}
		}

		var K = R.OrderBy(pos => pos.x).ToList();

		V = new bool[N];
		int r = 0;
		int k = R[0].w;
		Push(Create(0, 0));
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.w == k)
			{
				r++;
				continue;
			}

			foreach (int l in L[p.x])
			{
				Push(Create(l, p.w + 1));
			}
		}

		return (K[0].x + 1) + " " + K[0].w + " " + r;
	}

	public static int N, M;
	public static bool[] V;
	public static Queue<Pos> Q;
	public static List<int>[] L;

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]) - 1);
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]) - 1);
		}
		Q = new Queue<Pos>();
		Push(Create(0, 0));

		Console.WriteLine(BFS());
	}
}