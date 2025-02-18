#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

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
	public static int[,] T;
	public static bool[] VT = new bool[26];
	public static bool[,] V;
	public static List<int> L = new List<int>();
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void DFS(int depth, int x, int y)
	{
		int R = 0;

		for (int i = 0; i < 4; i++)
		{
			int X = x + dx[i];
			int Y = y + dy[i];
			if (X < 0 || X >= N || Y < 0 || Y >= M) continue;
			if (!V[X, Y] && !VT[T[X, Y]])
			{
				VT[T[X, Y]] = true;
				V[X, Y] = true;
				DFS(depth + 1, X, Y);
				VT[T[X, Y]] = false;
				V[X, Y] = false;
				R++;
			}
		}

		if (R == 0)
		{
			L.Add(depth);
			return;
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
				T[i, j] = S[0][j] - 'A';
			}
		}

		VT[T[0, 0]] = true;
		V[0, 0] = true;
		DFS(1, 0, 0);

		L.Sort();

		Console.WriteLine(L[L.Count - 1]);
	}
}