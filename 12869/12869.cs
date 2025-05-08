#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int DFS(int T1, int T2, int T3)
	{
		int r = int.MaxValue;

		T1 = Math.Max(0, T1);
		T2 = Math.Max(0, T2);
		T3 = Math.Max(0, T3);

		if (T1 == 0 && T2 == 0 && T3 == 0) return 0;
		if (DP[T1, T2, T3] != 0) return DP[T1, T2, T3];

		for (int i = 0; i < 6; i++)
		{
			int k = 1 + DFS(T1 + dx[i], T2 + dy[i], T3 + dz[i]);
			r = Math.Min(r, k);
		}

		DP[T1, T2, T3] = r;

		return r;
	}

	public static int N;
	public static int[,,] DP;

	public static int[] dx = { -9, -9, -3, -3, -1, -1 };
	public static int[] dy = { -3, -1, -9, -1, -9, -3 };
	public static int[] dz = { -1, -3, -1, -9, -3, -9 };

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		int[] T = new int[3];
		DP = new int[61, 61, 61];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		Console.WriteLine(DFS(T[0], T[1], T[2]));
	}
}