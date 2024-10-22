#pragma warning disable CS8600, CS8602, CS8604

using System;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
S = Console.ReadLine().Split(' ');
int[] T = new int[N];
int K = 0;

for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(S[i]);
}

for (int i = 0; i < N - 2; i++)
{
	for (int j = i + 1; j < N - 1; j++)
	{
		for (int k = j + 1; k < N; k++)
		{
			if (T[i] + T[j] + T[k] <= M && T[i] + T[j] + T[k] > K) K = T[i] + T[j] + T[k];
		}
	}
}

Console.WriteLine(K);