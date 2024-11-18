#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
string[] S1 = Console.ReadLine().Split(' ');
string[] S2 = Console.ReadLine().Split(' ');
int K = int.Parse(Console.ReadLine());
string[] S3 = Console.ReadLine().Split(' ');
StringBuilder sb = new StringBuilder();
int C = 0;

for (int i = N - 1; i >= 0; i--)
{
	if (int.Parse(S1[i]) == 0)
	{
		if (C != K)
		{
			sb.Append(int.Parse(S2[i]) + " ");
			C++;
		}
	}
}

for (int i = 0; i < K; i++)
{
	if (C != K)
	{
		sb.Append(S3[i] + " ");
		C++;
	}
	else break;
}

Console.WriteLine(sb);