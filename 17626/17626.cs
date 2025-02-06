#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static bool[] B = new bool[50000];
	public static List<int> L = new List<int>();

	public static int Cal(int N, int M)
	{
		if (B[N - 1]) return 1;

		for (int i = 0; i < M; i++)
		{
			if (L[i] > N) break;
			if (B[N - L[i] - 1]) return 2;
		}

		for (int i = 0; i < M; i++)
		{
			if (L[i] > N) break;
			for (int j = i; j < M; j++)
			{
				if (L[i] + L[j] > N) break;
				if (B[N - L[i] - L[j] - 1]) return 3;
			}
		}

		return 4;
	}

	public static void Main(string[] args)
	{
		for (int i = 1; i * i <= 50000; i++)
		{
			B[i * i - 1] = true;
			L.Add(i * i);
		}

		int N = int.Parse(Console.ReadLine());

		Console.WriteLine(Cal(N, L.Count));
	}
}