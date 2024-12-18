#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split(' ');
	int H = int.Parse(S[0]);
	int W = int.Parse(S[1]);
	int K = int.Parse(S[2]);

	if (K % H == 0)
	{
		sb.Append(H + "");
		if (K / H < 10) sb.Append("0");
		sb.AppendLine(K / H + "");
	}
	else
	{
		sb.Append(K % H + "");
		if (K / H + 1 < 10) sb.Append("0");
		sb.AppendLine((K / H + 1) + "");
	}
}

Console.WriteLine(sb);