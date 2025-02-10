#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N = 100001;
	public static int[,] V = new int[N, 2];
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
				L.Add(p.y);
				continue;
			}

			Push(Create(p.x * 2, p.y));
			Push(Create(p.x - 1, p.y + 1));
			Push(Create(p.x + 1, p.y + 1));
		}
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N) return null;
		if (V[x, 0] == 1)
		{
			if (V[x, 1] <= y) return null;
			else V[x, 1] = y;
		}

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, 0] = 1;
		V[pos.x, 1] = pos.y;

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		int A = int.Parse(S[0]);
		int B = int.Parse(S[1]);

		Push(Create(A, 0));
		BFS(B);
		L.Sort();

		if (L.Count == 0) Console.WriteLine(-1);
		else Console.WriteLine(L[0]);
	}
}