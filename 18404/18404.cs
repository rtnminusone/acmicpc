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

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (D.TryGetValue((p.x, p.y), out int w))
			{
				R[w] = p.w;
				D.Remove((p.x, p.y));
				if (D.Count == 0) break;
			}

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}
	}

	public static int N, M;
	public static int[] R;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static Dictionary<(int, int), int> D = new Dictionary<(int, int), int>();

	public static int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
	public static int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		R = new int[M];
		V = new bool[N, N];
		Q = new Queue<Pos>();
		S = Console.ReadLine().Split();
		Push(Create(int.Parse(S[0]) - 1, int.Parse(S[1]) - 1, 0));

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			D[(int.Parse(S[0]) - 1, int.Parse(S[1]) - 1)] = i;
		}

		BFS();

		Console.WriteLine(string.Join(" ", R));
	}
}