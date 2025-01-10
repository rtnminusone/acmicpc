#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int M;
	public static int N;

	public static void SearchSquare(int x, int y, int[, ] H, bool[, ] V)
	{
		if (x < 0 || x >= M || y < 0 || y >= N) return;
		if (V[x, y]) return;
		if (H[x, y] == 0) return;
		V[x, y] = true;
		SearchSquare(x - 1, y, H, V);
		SearchSquare(x + 1, y, H, V);
		SearchSquare(x, y - 1, H, V);
		SearchSquare(x, y + 1, H, V);
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int T = int.Parse(Console.ReadLine());

		for (int i = 0; i < T; i++)
		{
			string[] S = Console.ReadLine().Split();
			M = int.Parse(S[0]);
			N = int.Parse(S[1]);
			int K = int.Parse(S[2]);
			int[, ] H = new int[M, N];
			bool[, ] V = new bool[M, N];
			int R = 0;

			for (int j = 0; j < K; j++)
			{
				S = Console.ReadLine().Split();
				H[int.Parse(S[0]), int.Parse(S[1])] = 1;
			}

			for (int j = 0; j < M; j++)
			{
				for (int k = 0; k < N; k++)
				{
					if (H[j, k] == 1 && !V[j, k])
					{
						SearchSquare(j, k, H, V);
						R++;
					}
				}
			}

			sb.AppendLine(R + "");
		}

		Console.WriteLine(sb);
	}
}