#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int[, ] D;
	public static bool[] B;

	public static void DFS(int K)
	{
		if (B[K - 1]) return;
		B[K - 1] = true;

		for (int i = 0; i < N; i++)
		{
			if (K - 1 == i) continue;
			if (D[K - 1, i] != 0)
			{
				DFS(i + 1);
			}
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		int M = int.Parse(Console.ReadLine());

		D = new int[N, N];
		B = new bool[N];

		for (int i = 0; i < M; i++)
		{
			string[] S = Console.ReadLine().Split();
			D[int.Parse(S[0]) - 1, int.Parse(S[1]) - 1] = 1;
			D[int.Parse(S[1]) - 1, int.Parse(S[0]) - 1] = 1;
		}

		DFS(1);

		int C = 0;
		for (int i = 1; i < N; i++)
		{
			if (B[i] == true) C++; 
		}
		Console.WriteLine(C);
	}
}