#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
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

	public static int N;
	public static int M;
	public static int R = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 0) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
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
			Pos q = Q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				Push(Create(q.x + dx[i], q.y + dy[i]));
			}
		}
	}

	public static void Main(string[] args)
	{
		int K = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		while (K-- != 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			T = new int[N, M];
			V = new bool[N, M];
			Q = new Queue<Pos>();
			R = 0;

			for (int i = 0; i < N; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					if (S[0][j] == '#') T[i, j] = 1;
					else T[i, j] = 0;
				}
			}

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] == 1 && !V[i, j])
					{
						Push(Create(i, j));
						BFS();
						R++;
					}
				}
			}

			sb.AppendLine(R + "");
		}

		Console.WriteLine(sb);
	}
}