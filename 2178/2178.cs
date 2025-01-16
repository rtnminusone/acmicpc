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
	public static int[,] R;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (V[x, y] || T[x, y] != 1) return null;
		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos != null)
		{
			Q.Enqueue(pos);
			V[pos.x, pos.y] = true;
			return true;
		}
		return false;
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Pos pos = Q.Dequeue();
			if (pos.x == N - 1 && pos.y == M - 1) return;

			if (Push(Create(pos.x - 1, pos.y))) R[pos.x - 1, pos.y] = R[pos.x, pos.y] + 1;
			if (Push(Create(pos.x + 1, pos.y))) R[pos.x + 1, pos.y] = R[pos.x, pos.y] + 1;
			if (Push(Create(pos.x, pos.y - 1))) R[pos.x, pos.y - 1] = R[pos.x, pos.y] + 1;
			if (Push(Create(pos.x, pos.y + 1))) R[pos.x, pos.y + 1] = R[pos.x, pos.y] + 1;
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		R = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
			}
		}

		R[0, 0] = 1;
		Push(Create(0, 0));
		BFS();

		Console.WriteLine(R[N - 1, M - 1]);
	}
}

/* DFS Solve
class Program
{
	public static int N;
	public static int M;
	public static int[,] T;
	public static bool[,] V;
	public static List<int> L = new List<int>();

	public static void back_tracking(int depth, int x, int y)
	{
		if (x == N - 1 && y == M - 1)
		{
			L.Add(depth);
			return;
		}

		if (x - 1 >= 0 && !V[x - 1, y] && T[x - 1, y] == 1)
		{
			V[x - 1, y] = true;
			back_tracking(depth + 1, x - 1, y);
			V[x - 1, y] = false;
		}
		if (x + 1 < N && !V[x + 1, y] && T[x + 1, y] == 1)
		{
			V[x + 1, y] = true;
			back_tracking(depth + 1, x + 1, y);
			V[x + 1, y] = false;
		}
		if (y - 1 >= 0 && !V[x, y - 1] && T[x, y - 1] == 1)
		{
			V[x, y - 1] = true;
			back_tracking(depth + 1, x, y - 1);
			V[x, y - 1] = false;
		}
		if (y + 1 < M && !V[x, y + 1] && T[x, y + 1] == 1)
		{
			V[x, y + 1] = true;
			back_tracking(depth + 1, x, y + 1);
			V[x, y + 1] = false;
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
			}
		}

		V[0, 0] = true;
		back_tracking(1, 0, 0);

		L.Sort();

		Console.WriteLine(L[0]);
	}
}
*/