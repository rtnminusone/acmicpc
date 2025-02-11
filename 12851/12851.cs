#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int K;
	public static int R = int.MaxValue;

	public static bool[] V = new bool[100001];
	public static List<int> L = new List<int>();
	public static Queue<Pos> Q = new Queue<Pos>();

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

	public static void BFS(int goal)
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal)
			{
				if (p.y < R)
				{
					R = p.y;
					L = new List<int>();
					L.Add(R);
				}
				else if (p.y == R)
				{
					L.Add(p.y);
				}
			}

			V[p.x] = true;

			Push(Create(p.x + 1, p.y + 1));
			Push(Create(p.x - 1, p.y + 1));
			Push(Create(p.x * 2, p.y + 1));
		}
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x > 100000) return null;
		if (V[x]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos p)
	{
		if (p == null) return false;
		if (V[p.x]) return false;

		Q.Enqueue(p);

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);

		Q.Enqueue(new Pos(N, 0));

		BFS(K);

		L.Sort();

		Console.WriteLine(L[0]);
		Console.WriteLine(L.Count);
	}
}