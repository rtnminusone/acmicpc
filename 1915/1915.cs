#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
int[,] T = new int[N, M];
int[,] DP = new int[N, M];

for (int i = 0; i < N; i++)
{
	S[0] = Console.ReadLine();
	for (int j = 0; j < M; j++)
	{
		T[i, j] = S[0][j] - '0';
		if (T[i, j] == 1) DP[i, j] = 1;
	}
}

int R = int.MinValue;
for (int i = 0; i < N; i++)
{
	if (T[i, 0] == 1) R = 1;
}
for (int j = 0; j < M; j++)
{
	if (T[0, j] == 1) R = 1;
}

for (int i = 1; i < N; i++)
{
	for (int j = 1; j < M; j++)
	{
		if (T[i, j] == 1)
		{
			DP[i, j] = Math.Min(Math.Min(DP[i - 1, j], DP[i, j - 1]), DP[i - 1, j - 1]) + 1;
			if (R < DP[i, j]) R = DP[i, j];
		}
	}
}

Console.WriteLine(R * R);