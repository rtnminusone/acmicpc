#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

int T = int.Parse(Console.ReadLine());
int K = 0, N = 0;
StringBuilder sb = new StringBuilder();

for (int i = 0; i < T; i++)
{
	K = int.Parse(Console.ReadLine());
	N = int.Parse(Console.ReadLine());

	int[,] B = new int[K + 1, N];

	for (int j = 0; j < N; j++)
	{
		B[0, j] = j + 1;
	}

	for (int j = 1; j <= K; j++)
	{
		for (int k = 0; k < N; k++)
		{
			for (int l = 0; l <= k; l++)
			{
				B[j, k] += B[j - 1, l];
			}
		}
	}

	sb.AppendLine(B[K, N - 1] + "");
}

Console.WriteLine(sb);