#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int[] T;

	public static int BS(int start, int end)
	{
		if (start > end) return end;
		int mid = (start + end) / 2;
		int R = Cal(mid);

		if (R > M) return BS(start, mid - 1);
		else if (R < M) return BS(mid + 1, end);
		else return mid;
	}

	public static int Cal(int goal)
	{
		int R = 0;

		for (int i = 0; i < N; i++)
		{
			if (T[i] >= goal) R += goal;
			else R += T[i];
		}

		return R;
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
		Array.Sort(T);
		M = int.Parse(Console.ReadLine());

		Console.WriteLine(BS(M / N, T[N - 1]));
	}
}