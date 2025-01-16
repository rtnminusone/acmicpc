#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

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
	public static int M;
	public static int R = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[x, y]) return null;
		return new Pos(x, y);
	}

	public static void Push(Pos pos)
	{
		if (pos == null) return;
		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;
	}

	public static void Check(Pos pos)
	{
		if (T[pos.x, pos.y] == 1) R++;
		Push(Create(pos.x - 1, pos.y));
		Push(Create(pos.x + 1, pos.y));
		Push(Create(pos.x, pos.y - 1));
		Push(Create(pos.x, pos.y + 1));
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == 'P') T[i, j] = 1;
				else if (S[0][j] == 'X') V[i, j] = true;
				else if (S[0][j] == 'I') Push(Create(i, j));
			}
		}

		while (Q.Count != 0)
		{
			Check(Q.Dequeue());
		}

		if (R == 0) Console.WriteLine("TT");
		else Console.WriteLine(R);
	}
}