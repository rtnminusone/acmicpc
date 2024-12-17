#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int K = int.Parse(S[1]);
int[] W = new int[N];
int[] V = new int[N];
int[,] DP = new int[N + 1, K + 1];

for (int i = 0; i < N; i++)
{
	S = Console.ReadLine().Split(' ');
	W[i] = int.Parse(S[0]);
	V[i] = int.Parse(S[1]);
}

for (int w = 1; w <= K; w++)
{
	for (int n = 1; n <= N; n++)
	{
		if (w < W[n - 1]) DP[n, w] = DP[n - 1, w];
		else DP[n, w] = Math.Max(DP[n - 1, w], DP[n - 1, w - W[n - 1]] + V[n - 1]);
	}
}

Console.WriteLine(DP[N, K]);