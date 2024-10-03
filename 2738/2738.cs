#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		string[] s = Console.ReadLine().Split(' ');

		int[,] r = new int[int.Parse(s[0]), int.Parse(s[1])];

		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < int.Parse(s[0]); j++)
			{
				string[] b = Console.ReadLine().Split(' ');

				for (int k = 0; k < int.Parse(s[1]); k++)
				{
					r[j, k] += int.Parse(b[k]);
				}
			}
		}

		for (int i = 0; i < int.Parse(s[0]); i++)
		{
			for (int j = 0; j < int.Parse(s[1]); j++)
			{
				Console.Write(r[i, j] + " ");
			}
			Console.WriteLine();
		}
	}
}