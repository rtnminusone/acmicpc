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
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 1) return null;
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

	public static void BFS(int key)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			K[key, p.x, p.y] = p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}
	}

	public static int N, M;
	public static int[,] T;
	public static int[,,] K;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		K = new int[3, N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
				for (int k = 0; k < 3; k++)
				{
					K[k, i, j] = -1;
				}
			}
		}

		for (int i = 0; i < 3; i++)
		{
			S = Console.ReadLine().Split();
			V = new bool[N, M];
			Q = new Queue<Pos>();
			Push(Create(int.Parse(S[0]) - 1, int.Parse(S[1]) - 1, 0));
			BFS(i);
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (K[0, i, j] >= 0 && K[1, i, j] >= 0 && K[2, i, j] >= 0)
				{
					int m = Math.Max(Math.Max(K[0, i, j], K[1, i, j]), K[2, i, j]);
					if (D.ContainsKey(m)) D[m]++;
					else D[m] = 1;
				}
			}
		}

		if (D.Keys.Count == 0) Console.WriteLine(-1);
		else Console.WriteLine(D.Keys.Min() + "\n" + D[D.Keys.Min()]);
	}
}