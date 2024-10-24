#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
int R = 0;

for (int i = 1; i < N; i++)
{
	string S = i.ToString();
	int K = i;
	for (int j = 0; j < S.Length; j++)
	{
		K += S[j] - '0';
	}
	if (K == N)
	{
		R = i;
		break;
	}
}

Console.WriteLine(R);