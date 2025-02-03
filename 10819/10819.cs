#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int[] T;
	public static int[] W;
	public static bool[] V;
	public static int R = int.MinValue;

	public static void DFS(int depth)
	{
		if (depth == N)
		{
			int result = Cal();
			if (R < result) R = result;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (!V[i])
			{
				V[i] = true;
				W[depth] = T[i];
				DFS(depth + 1);
				V[i] = false;
			}
		}
	}

	public static int Cal()
	{
		int result = 0;

		for (int i = 0; i < N - 1; i++)
		{
			result += Math.Abs(W[i] - W[i + 1]);
		}

		return result;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		W = new int[N];
		V = new bool[N];

		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		DFS(0);

		Console.WriteLine(R);
	}
}