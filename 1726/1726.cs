#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int d;
		public int x;
		public int y;
		public int w;

		public Pos(int d, int x, int y, int w)
		{
			this.d = d;
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static int Dir(int dir, int lr)
	{
		if (lr == 0)
		{
			dir++;
			if (dir > 3) dir = 0;
		}
		else
		{
			dir--;
			if (dir < 0) dir = 3;
		}

		return dir;
	}

	public static int Conv(int dir)
	{
		if (dir == 1) return 1;
		else if (dir == 2) return 3;
		else if (dir == 3) return 2;
		else return 0;
	}

	public static Pos Create(int d, int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 1) return null;

		return new Pos(d, x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		if (V[pos.d, pos.x, pos.y]) return false;

		Q.Enqueue(pos);
		V[pos.d, pos.x, pos.y] = true;

		return true;
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.d == D && p.x == X && p.y == Y) return p.w;

			for (int i = 0; i < 3; i++)
			{
				Pos temp = Create(p.d, p.x + dx[p.d, i], p.y + dy[p.d, i], p.w + 1);
				if (temp == null) break;
				Push(temp);
			}

			for (int i = 0; i < 2; i++)
			{
				Push(Create(Dir(p.d, i), p.x, p.y, p.w + 1));
			}
		}

		return -1;
	}

	public static int N, M;
	public static int X, Y, D;
	public static int[,] T;
	public static bool[,,] V;
	public static Queue<Pos> Q;

	public static int[,] dx = { { -1, -2, -3 }, { 0, 0, 0 }, { 1, 2, 3 }, { 0, 0, 0 } };
	public static int[,] dy = { { 0, 0, 0 }, { 1, 2, 3 }, { 0, 0, 0 }, { -1, -2, -3 } };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[4, N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		S = Console.ReadLine().Split();
		Push(Create(Conv(int.Parse(S[2])), int.Parse(S[0]) - 1, int.Parse(S[1]) - 1, 0));

		S = Console.ReadLine().Split();
		X = int.Parse(S[0]) - 1;
		Y = int.Parse(S[1]) - 1;
		D = Conv(int.Parse(S[2]));

		Console.WriteLine(BFS());
	}
}