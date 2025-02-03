#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

int N = int.Parse(Console.ReadLine());
int[,] T = new int[N, 5];
int[,] W = new int[N, 5];
bool[,] B = new bool[N, N];

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	for (int j = 0; j < 5; j++)
	{
		T[i, j] = int.Parse(S[j]);
	}
}

for (int i = 0; i < N; i++)
{
	for (int j = i + 1; j < N; j++)
	{
		for (int k = 0; k < 5; k++)
		{
			if (T[i, k] == T[j, k])
			{
				B[i, j] = true;
				B[j, i] = true;
				break;
			}
		}
	}
}

int K = int.MinValue;
int R = int.MinValue;
for (int i = 0; i < N; i++)
{
	int SUM = 0;
	for (int j = 0; j < N; j++)
	{
		if (B[i, j]) SUM++;
	}
	if (SUM > K)
	{
		K = SUM;
		R = i + 1;
	}
}

Console.WriteLine(R);