#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
int[,] Board = new int[N, M];
int[] R = new int[2];
int result = int.MaxValue;

for (int i = 0; i < N; i++)
{
	char[] C = Console.ReadLine().ToCharArray();
	for (int j = 0; j < M; j++)
	{
		Board[i, j] = C[j];
	}
}

int F;
for (int i = 0; i <= N - 8; i++)
{
	for (int j = 0; j <= M - 8; j++)
	{
		F = 'W';
		R[0] = 0;
		for (int k = 0; k < 8; k++)
		{
			for (int l = 0; l < 8; l++)
			{
				if (l % 2 == 0)
				{
					if (Board[i + k, j + l] != F) R[0]++;
				}
				else
				{
					if (Board[i + k, j + l] == F) R[0]++;
				}
			}
			if (F == 'W') F = 'B';
			else F = 'W';
		}

		F = 'B';
		R[1] = 0;
		for (int k = 0; k < 8; k++)
		{
			for (int l = 0; l < 8; l++)
			{
				if (l % 2 == 0)
				{
					if (Board[i + k, j + l] != F) R[1]++;
				}
				else
				{
					if (Board[i + k, j + l] == F) R[1]++;
				}
			}
			if (F == 'W') F = 'B';
			else F = 'W';
		}

		result = Math.Min(result, Math.Min(R[0], R[1]));
	}
}

Console.WriteLine(result);