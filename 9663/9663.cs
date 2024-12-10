#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int N;
	public static int count = 0;

	public static void nqueen(bool[,] NQ, int row)
	{
		if (row == N)
		{
			count++;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (check(NQ, row, i))
			{
				NQ[row, i] = true;
				nqueen(NQ, row + 1);
				NQ[row, i] = false;
			}
		}
	}

	public static bool check(bool[,] NQ, int row, int col)
	{
		for (int i = 0; i < row; i++)
		{
			if (NQ[i, col]) return false;
		}

		for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
		{
			if (NQ[i, j]) return false;
		}

		for (int i = row - 1, j = col + 1; i >=0 && j < N; i--, j++)
		{
			if (NQ[i, j]) return false;
		}

		return true;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		bool[,] NQ = new bool[N, N];
		
		Array.Clear(NQ, 0, NQ.Length);

		nqueen(NQ, 0);

		Console.WriteLine(count);
	}
}