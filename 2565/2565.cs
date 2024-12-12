#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
Dictionary<int, int> D = new Dictionary<int, int>();
int[] DP = new int[N];

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split(' ');
	D.Add(int.Parse(S[0]), int.Parse(S[1]));
}

int[] B = D.OrderBy(dict => dict.Key).Select(dict => dict.Value).ToArray();

for (int i = 0; i < N; i++)
{
	DP[i] = 1;
	for (int j = 0; j < i; j++)
	{
		if (B[j] < B[i]) DP[i] = Math.Max(DP[i], DP[j] + 1);
	}
}

Array.Sort(DP);

Console.WriteLine(N - DP[N - 1]);