#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static long M;

	public static long[] T;

	public static long BS(long start, long end)
	{
		if (start > end) return end;

		long mid = (start + end) / 2;
		long cal = CalLength(mid);

		if (cal >= M) return BS(mid + 1, end);
		else return BS(start, mid - 1);
	}

	public static long CalLength(long len)
	{
		long SUM = 0;

		for (int i = 0; i < N; i++)
		{
			if (T[i] > len) SUM += T[i] - len;
		}

		return SUM;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new long[N];
		S = Console.ReadLine().Split();

		for (int i = 0; i < N; i++)
		{
			T[i] = long.Parse(S[i]);
		}

		Array.Sort(T);

		Console.WriteLine(BS(0, T[N - 1]));
	}
}