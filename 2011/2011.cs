#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static string S;
	public static int N;

	public static bool Cal(int cur, int len)
	{
		int A = 0;
		if (len == 1)
		{
			A = S[cur] - '0';
			if (A <= 0) return false;
		}
		else
		{
			A = (S[cur] - '0') * 10 + (S[cur + 1] - '0');
			if (A < 10 || A > 26) return false;
		}

		return true;
	}

	public static void Main(string[] args)
	{
		S = Console.ReadLine();
		N = S.Length;
		int[] DP = new int[N + 1];
		DP[0] = 1;
		if (Cal(0, 1)) DP[1] = 1;

		for (int i = 2; i <= N && DP[1] != 0; i++)
		{
			if (Cal(i - 2, 2)) DP[i] += DP[i - 2];
			if (Cal(i - 1, 1)) DP[i] += DP[i - 1];
			DP[i] %= 1000000;
		}

		Console.WriteLine(DP[N]);
	}
}