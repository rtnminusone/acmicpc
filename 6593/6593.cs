#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int z;
		public int x;
		public int y;
		public int w;

		public Pos(int z, int x, int y, int w)
		{
			this.z = z;
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static int N;
	public static int M;
	public static int K;
	public static int[,,] T;
	public static bool[,,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 0, 1, 0, 0 };
	public static int[] dy = { 0, -1, 0, 0, 1, 0 };
	public static int[] dz = { 0, 0, -1, 0, 0, 1 };

	public static Pos Create(int z, int x, int y, int w)
	{
		if (z < 0 || z >= K || x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[z, x, y]) return null;
		if (T[z, x, y] == 0) return null;

		return new Pos(z, x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.z, pos.x, pos.y] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.z, p.x, p.y] == 2) return p.w;

			for (int i = 0; i < 6; i++)
			{
				Push(Create(p.z + dz[i], p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			K = int.Parse(S[0]);
			N = int.Parse(S[1]);
			M = int.Parse(S[2]);
			if (N == 0 || M == 0 || K == 0) break;
			T = new int[K, N, M];
			V = new bool[K, N, M];
			Q = new Queue<Pos>();

			for (int k = 0; k < K; k++)
			{
				for (int i = 0; i < N; i++)
				{
					S[0] = Console.ReadLine();
					for (int j = 0; j < M; j++)
					{
						if (S[0][j] == 'S')
						{
							T[k, i, j] = 1;
							Push(Create(k, i, j, 0));
						}
						else if (S[0][j] == '.') T[k, i, j] = 1;
						else if (S[0][j] == 'E') T[k, i, j] = 2;
						else T[k, i, j] = 0;
					}
				}
				Console.ReadLine();
			}

			int R = BFS();
			if (R < 0) sb.AppendLine("Trapped!");
			else sb.AppendLine("Escaped in " + R + " minute(s).");
		}

		Console.WriteLine(sb);
	}
}