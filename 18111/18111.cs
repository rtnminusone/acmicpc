#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int B;
	public static int[,] T;

	public static int Check(int goal, int b)
	{
		int t = 0;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] > goal)
				{
					b += T[i, j] - goal;
					t += (T[i, j] - goal) * 2;
				}
				else
				{
					b -= goal - T[i, j];
					t += goal - T[i, j];
				}
			}
		}

		if (b < 0) return int.MaxValue;

		return t;
	}

	public static void Main(string[] args)
	{
		Dictionary<int, int> D = new Dictionary<int, int>();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		B = int.Parse(S[2]);

		T = new int[N, M];

		int Min = int.MaxValue, Max = int.MinValue;

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] > Max) Max = T[i, j];
				if (T[i, j] < Min) Min = T[i, j];
			}
		}

		for (int i = Max; i >= Min; i--)
		{
			int R = Check(i, B);
			if (R == int.MaxValue) continue;
			if (D.ContainsKey(R))
			{
				if (D[R] < i) D[R] = i;
			}
			else D[R] = i;
		}

		var V = D.OrderBy(k => k.Key).ToList();

		Console.WriteLine(V[0].Key + " " + V[0].Value);
	}
}