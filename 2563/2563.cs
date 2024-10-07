#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int[,] n = new int[100, 100];
		int N = int.Parse(Console.ReadLine());
		int R = 0;

		for (int i = 0; i < N; i++)
		{
			string[] b = Console.ReadLine().Split(' ');

			for (int j = int.Parse(b[0]); j < int.Parse(b[0]) + 10; j++)
			{
				for (int k = int.Parse(b[1]); k < int.Parse(b[1]) + 10; k++)
				{
					n[j, k] = 1;
				}
			}
		}

		for (int i = 0; i < 100; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				R += n[i, j];
			}
		}

		Console.WriteLine(R);
	}
}