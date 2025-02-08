#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public bool z;

		public Pos(int x, int y, bool z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}

	public static int N;
	public static int M;
	public static int[,] T;
	public static int[,,] W;
	public static bool[,,] V;
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };
	public static Queue<Pos> Q;

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			int f = p.z ? 1 : 0;

			if (p.x == N - 1 && p.y == M - 1) return W[p.x, p.y, f] + 1;

			for (int i = 0; i < 4; i++)
			{
				Pos temp = Create(p.x + dx[i], p.y + dy[i], p.z);

				if (Push(temp))
				{
					W[p.x + dx[i], p.y + dy[i], temp.z ? 1 : 0] = W[p.x, p.y, f] + 1;
				}
			}
		}

		return -1;
	}

	public static Pos Create(int x, int y, bool z)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if ((z && V[x, y, 1]) || (!z && V[x, y, 0])) return null;
		if (T[x, y] == 1)
		{
			if (!z) return new Pos(x, y, true);
			return null;
		}

		return new Pos(x, y, z);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		if (V[pos.x, pos.y, pos.z ? 1 : 0]) return false;

		V[pos.x, pos.y, pos.z ? 1 : 0] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		W = new int[N, M, 2];
		V = new bool[N, M, 2];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			string S2 = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S2[j] - '0';
			}
		}

		V[0, 0, 0] = true;
		Q.Enqueue(new Pos(0, 0, false));

		Console.WriteLine(BFS());
	}
}