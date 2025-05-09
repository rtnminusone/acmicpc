#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public int w;

		public Pos(int x, int y, int w)
		{
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (V[x, y]) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == R2 && p.y == C2) return p.w;

			for (int i = 0; i < 6; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static int N;
	public static int R1, R2, C1, C2;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -2, -2, 0, 0, 2, 2 };
	public static int[] dy = { -1, 1, -2, 2, -1, 1 };

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N, N];
		Q = new Queue<Pos>();
		string[] S = Console.ReadLine().Split();
		R1 = int.Parse(S[0]);
		C1 = int.Parse(S[1]);
		R2 = int.Parse(S[2]);
		C2 = int.Parse(S[3]);

		Push(Create(R1, C1, 0));
		Console.WriteLine(BFS());
	}
}