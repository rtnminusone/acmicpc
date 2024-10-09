#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int K = 3;

		for (int i = 1; i < N; i++)
		{
			K = 2 * K - 1;
		}

		Console.WriteLine(K * K);
	}
}