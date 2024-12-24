#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

List<int> L = new List<int>();
int N = int.Parse(Console.ReadLine());

if (N == 0) Console.WriteLine(0);
else
{
	for (int i = 0; i < N; i++)
	{
		L.Add(int.Parse(Console.ReadLine()));
	}

	L.Sort();

	int K = (int)Math.Round((double)N * 15 / 100, 0, MidpointRounding.AwayFromZero);
	int A = 0;

	for (int i = K; i < L.Count - K; i++)
	{
		A += L[i];
	}

	Console.WriteLine((int)Math.Round((double)A / (L.Count - (K * 2)), 0, MidpointRounding.AwayFromZero));
}