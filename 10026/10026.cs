#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N;
	public static char[][] T;
	public static bool[,] B;
	public static Queue<Pos> Q;

	public static bool RGFLAG = false;

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= N) return null;
		if (B[x, y]) return null;

		return new Pos(x, y);
	}

	public static void Push(Pos p, char org)
	{
		if (p == null) return;

		if (RGFLAG && (org == 'R' || org == 'G'))
		{
			if (T[p.x][p.y] == 'B') return;
		}
		else
		{
			if (T[p.x][p.y] != org) return;
		}

		Q.Enqueue(p);
		B[p.x, p.y] = true;
	}

	public static void SIMUL()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			Push(Create(p.x - 1, p.y), T[p.x][p.y]);
			Push(Create(p.x + 1, p.y), T[p.x][p.y]);
			Push(Create(p.x, p.y - 1), T[p.x][p.y]);
			Push(Create(p.x, p.y + 1), T[p.x][p.y]);
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new char[N][];
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			T[i] = Console.ReadLine().ToCharArray();
		}

		Q = new Queue<Pos>();
		B = new bool[N, N];
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (B[i, j]) continue;
				Q.Enqueue(new Pos(i, j));
				B[i, j] = true;
				SIMUL();
				R++;
			}
		}
		sb.Append(R + " ");

		Q = new Queue<Pos>();
		B = new bool[N, N];
		R = 0;
		RGFLAG = true;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (B[i, j]) continue;
				Q.Enqueue(new Pos(i, j));
				B[i, j] = true;
				SIMUL();
				R++;
			}
		}

		Console.WriteLine(sb.ToString() + R);
	}
}