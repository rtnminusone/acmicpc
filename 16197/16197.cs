#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int x1;
		public int y1;
		public int x2;
		public int y2;
		public int w;

		public Pos(int x1, int y1, int x2, int y2, int w)
		{
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.w = w;
		}
	}

	public static Pos Create(int x1, int y1, int x2, int y2, int xoff, int yoff, int w)
	{
		int r = 0;
		int X1 = x1 + xoff;
		int Y1 = y1 + yoff;
		int X2 = x2 + xoff;
		int Y2 = y2 + yoff;
		if (X1 < 0 || X1 >= N || Y1 < 0 || Y1 >= M)
		{
			r++;
		}
		if (X2 < 0 || X2 >= N || Y2 < 0 || Y2 >= M)
		{
			r++;
		}
		if (r != 0)
		{
			if (r == 1) B = true;
			return null;
		}
		if (T[X1, Y1] == 1)
		{
			X1 = x1;
			Y1 = y1;
		}
		if (T[X2, Y2] == 1)
		{
			X2 = x2;
			Y2 = y2;
		}
		if (V[X1, Y1, X2, Y2]) return null;

		return new Pos(X1, Y1, X2, Y2, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x1, pos.y1, pos.x2, pos.y2] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.w >= 10) return -1;

			for (int i = 0; i < 4; i++)
			{
				B = false;
				Pos t = Create(p.x1, p.y1, p.x2, p.y2, dx[i], dy[i], p.w + 1);
				if (B) return p.w + 1;
				Push(t);
			}
		}

		return -1;
	}

	public static int N, M;
	public static bool B = false;
	public static int[,] T;
	public static bool[,,,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { 0, 0, -1, 1 };
	public static int[] dy = { -1, 1, 0, 0 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M, N, M];
		Q = new Queue<Pos>();
		int x = -1, y = -1;
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == '#') T[i, j] = 1;
				else
				{
					T[i, j] = 0;
					if (S[0][j] == 'o')
					{
						if (!B)
						{
							x = i;
							y = j;
							B = true;
						}
						else Push(Create(x, y, i, j, 0, 0, 0));
					}
				}
			}
		}

		Console.WriteLine(BFS());
	}
}