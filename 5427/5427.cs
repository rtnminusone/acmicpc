#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;
using System.Text;

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
		if (V[x, y]) return null;
		if (T[x, y] == -1) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static string BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (F[p.x, p.y] <= p.w) continue;

			if (p.x == 0 || p.x == N - 1 || p.y == 0 || p.y == M - 1) return (p.w + 1) + "";

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return "IMPOSSIBLE";
	}

	public static void BFSF()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			F[p.x, p.y] = p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}
	}

	public static int N;
	public static int M;
	public static int[,] T;
	public static int[,] F;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static Pos p = null;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int K = int.Parse(Console.ReadLine());

		while (K-- != 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[1]);
			M = int.Parse(S[0]);
			T = new int[N, M];
			F = new int[N, M];
			V = new bool[N, M];
			Q = new Queue<Pos>();

			for (int i = 0; i < N; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					F[i, j] = int.MaxValue;
					if (S[0][j] == '#') T[i, j] = -1;
					else if (S[0][j] == '.') T[i, j] = 1;
					else if (S[0][j] == '@')
					{
						T[i, j] = 1;
						p = new Pos(i, j, 0);
					}
					else
					{
						T[i, j] = 0;
						Push(Create(i, j, 0));
					}
				}
			}

			BFSF();

			V = new bool[N, M];
			Q = new Queue<Pos>();

			Push(p);

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb);
	}
}