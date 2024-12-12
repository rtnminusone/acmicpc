#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int[,,] W = new int[101, 101, 101];
	public static StringBuilder sb = new StringBuilder();

	public static void INIT()
	{
		for (int i = 0; i <= 50; i++)
		{
			for (int j = 0; j < 101; j++)
			{
				for (int k = 0; k < 101; k++)
				{
					W[i, j, k] = 1;
					W[j, i, k] = 1;
					W[j, k, i] = 1;
				}
			}
		}

		for (int i = 71; i < 101; i++)
		{
			for (int j = 51; j < 101; j++)
			{
				for (int k = 51; k < 101; k++)
				{
					W[i, j, k] = 1048576;
					W[j, i, k] = 1048576;
					W[j, k, i] = 1048576;
				}
			}
		}
	}

	public static int DP(int a, int b, int c)
	{
		if (W[a, b, c] != 0) return W[a, b, c];
		if (a <= 50 || b <= 50 || c <= 50)
		{
			W[a, b, c] = 1;
			return 1;
		}
		else if (a > 70 || b > 70 || c > 70)
		{
			W[a, b, c] = 1048576;
			return 1048576;
		}
		else if (a < b && b < c)
		{
			W[a, b, c] = DP(a, b, c - 1) + DP(a, b - 1, c - 1) - DP(a, b - 1, c);
			return W[a, b, c];
		}
		else
		{
			W[a, b, c] = DP(a - 1, b, c) + DP(a - 1, b - 1, c) + DP(a - 1, b, c - 1) - DP(a - 1, b - 1, c - 1);
			return W[a, b, c];
		}
	}

	public static void Main(string[] args)
	{
		INIT();

		while (true)
		{
			string[] S = Console.ReadLine().Split(' ');
			int A = int.Parse(S[0]);
			int B = int.Parse(S[1]);
			int C = int.Parse(S[2]);
			int[,,] W = new int[20, 20, 20];

			if (A == -1 && B == -1 && C == -1) break;
			sb.AppendLine("w(" + A + ", " + B + ", " + C + ") = " + DP(A + 50, B + 50, C + 50));
		}

		Console.WriteLine(sb);
	}
}