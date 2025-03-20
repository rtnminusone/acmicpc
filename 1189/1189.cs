#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int R = 0;
	public static int[,] T;
	public static bool[,] V;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void DFS(int depth, int x, int y, int goal)
	{
		if (depth == goal)
		{
			if (x == 0 && y == M - 1) R++;
			return;
		}

		for (int i = 0; i < 4; i++)
		{
			if (x + dx[i] < 0 || x + dx[i] >= N || y + dy[i] < 0 || y + dy[i] >= M) continue;
			if (T[x + dx[i], y + dy[i]] == 0 && !V[x + dx[i], y + dy[i]])
			{
				V[x + dx[i], y + dy[i]] = true;
				DFS(depth + 1, x + dx[i], y + dy[i], goal);
				V[x + dx[i], y + dy[i]] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] == 'T' ? 1 : 0;
			}
		}

		V[N - 1, 0] = true;
		DFS(1, N - 1, 0, K);

		Console.WriteLine(R);
	}
}