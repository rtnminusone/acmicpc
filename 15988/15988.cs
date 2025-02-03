#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
int T = int.Parse(Console.ReadLine());

for (int i = 0; i < T; i++)
{
	int N = int.Parse(Console.ReadLine());
	long[] DP = new long[N];
	if (N == 1) sb.AppendLine("1");
	else if (N == 2) sb.AppendLine("2");
	else if (N == 3) sb.AppendLine("4");
	else
	{
		DP[0] = 1;
		DP[1] = 2;
		DP[2] = 4;

		for (int j = 3; j < N; j++)
		{
			DP[j] = DP[j - 3] + DP[j - 2] + DP[j - 1];
			DP[j] %= 1000000009;
		}

		sb.AppendLine(DP[N - 1] + "");
	}
}

Console.WriteLine(sb);