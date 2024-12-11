#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static bool check(int[,] SDQ, int value, int row, int col)
	{
		for (int i = 0; i < 9; i++)
		{
			if (SDQ[row, i] == value) return false;
			if (SDQ[i, col] == value) return false;
		}

		for (int i = row - row % 3; i < row - row % 3 + 3; i++)
		{
			for (int j = col - col % 3; j < col - col % 3 + 3; j++)
			{
				if (SDQ[i, j] == value) return false;
			}
		}

		return true;
	}

	public static bool sdq(int[,] SDQ)
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (SDQ[i, j] == 0)
				{
					for (int k = 1; k <= 9; k++)
					{
						if (check(SDQ, k, i, j))
						{
							SDQ[i, j] = k;
							if (!sdq(SDQ)) SDQ[i, j] = 0;
							else return true;
						}
					}
					return false;
				}
			}
		}

		return true;
	}

	public static void Main(string[] args)
	{
		int[,] SDQ = new int[9, 9];
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < 9; i++)
		{
			string[] S = Console.ReadLine().Split(' ');
			for (int j = 0; j < 9; j++)
			{
				SDQ[i, j] = int.Parse(S[j]);
			}
		}

		if (sdq(SDQ))
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					sb.Append(SDQ[i, j] + " ");
				}
				sb.Append("\n");
			}
		}

		Console.WriteLine(sb);
	}
}