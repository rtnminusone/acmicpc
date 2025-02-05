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
	public static int X;
	public static int Y;
	public static int D;
	public static int R = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static bool CheckAll(Pos pos)
	{
		if (pos.x - 1 >= 0 && T[pos.x - 1, pos.y] == 0 && !V[pos.x - 1, pos. y]) return true;
		if (pos.y - 1 >= 0 && T[pos.x, pos.y - 1] == 0 && !V[pos.x, pos. y - 1]) return true;
		if (pos.x + 1 < N && T[pos.x + 1, pos.y] == 0 && !V[pos.x + 1, pos. y]) return true;
		if (pos.y + 1 < M && T[pos.x, pos.y + 1] == 0 && !V[pos.x, pos. y + 1]) return true;

		return false;
	}

	public static Pos CheckFront(Pos pos)
	{
		if (D == 0 && pos.x - 1 >= 0 && T[pos.x - 1, pos.y] == 0 && !V[pos.x - 1, pos.y]) return new Pos(pos.x - 1, pos.y);
		if (D == 1 && pos.y + 1 < M && T[pos.x, pos.y + 1] == 0 && !V[pos.x, pos.y + 1]) return new Pos(pos.x, pos.y + 1);
		if (D == 2 && pos.x + 1 < N && T[pos.x + 1, pos.y] == 0 && !V[pos.x + 1, pos.y]) return new Pos(pos.x + 1, pos.y);
		if (D == 3 && pos.y - 1 >= 0 && T[pos.x, pos.y - 1] == 0 && !V[pos.x, pos.y - 1]) return new Pos(pos.x, pos.y - 1);

		return null;
	}

	public static Pos CheckBack(Pos pos)
	{
		if (D == 2 && pos.x - 1 >= 0 && T[pos.x - 1, pos.y] == 0) return new Pos(pos.x - 1, pos.y);
		if (D == 3 && pos.y + 1 < M && T[pos.x, pos.y + 1] == 0) return new Pos(pos.x, pos.y + 1);
		if (D == 0 && pos.x + 1 < N && T[pos.x + 1, pos.y] == 0) return new Pos(pos.x + 1, pos.y);
		if (D == 1 && pos.y - 1 >= 0 && T[pos.x, pos.y - 1] == 0) return new Pos(pos.x, pos.y - 1);

		return null;
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (!V[p.x, p.y] && T[p.x, p.y] == 0)
			{
				V[p.x, p.y] = true;
				R++;
			}

			if (CheckAll(p))
			{
				SetD();
				Pos t = CheckFront(p);
				if (t != null) Q.Enqueue(t);
				else Q.Enqueue(p);
			}
			else
			{
				Pos t = CheckBack(p);
				if (t != null) Q.Enqueue(t);
				else break;
			}
		}
	}

	public static void SetD()
	{
		D--;
		if (D < 0) D = 3;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		S = Console.ReadLine().Split();
		X = int.Parse(S[0]);
		Y = int.Parse(S[1]);
		D = int.Parse(S[2]);

		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		Q.Enqueue(new Pos(X, Y));

		BFS();

		Console.WriteLine(R);
	}
}