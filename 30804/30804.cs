#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int[] T;

	public static int TP()
	{
		Dictionary<int, int> D = new Dictionary<int, int>();
		int result = int.MinValue;
		int L = 0, R = 0;

		while (R < N)
		{
			if (D.ContainsKey(T[R])) D[T[R]]++;
			else D[T[R]] = 1;

			while (D.Count > 2)
			{
				D[T[L]]--;
				if (D[T[L]] == 0) D.Remove(T[L]);
				L++;
			}

			if (result < R - L + 1) result = R - L + 1;

			R++;
		}

		return result;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];

		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		Console.WriteLine(TP());
	}
}