#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int[] R = new int[2];

	public static void SquareSearch(int N, int x, int y, int[, ] T)
	{
		if (SquareCheck(N, x, y, T)) R[T[x, y]]++;
		else
		{
			SquareSearch(N / 2, x, y, T);
			SquareSearch(N / 2, x, y + (N / 2), T);
			SquareSearch(N / 2, x + (N / 2), y, T);
			SquareSearch(N / 2, x + (N / 2), y + (N / 2), T);
		}
	}

	public static bool SquareCheck(int N, int x, int y, int[, ] T)
	{
		int start = T[x, y];

		for (int i = x; i < x + N; i++)
		{
			for (int j = y; j < y + N; j++)
			{
				if (T[i, j] != start) return false;
			}
		}

		return true;
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int[, ] T = new int[N, N];

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		SquareSearch(N, 0, 0, T);

		Console.WriteLine(R[0] + "\n" + R[1]);
	}
}