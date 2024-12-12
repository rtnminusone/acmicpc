#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int[] DP = new int[N];

		if (N == 1)
		{
			Console.WriteLine("1");
			return;
		}
		if (N == 2)
		{
			Console.WriteLine("2");
			return;
		}

		DP[0] = 1;
		DP[1] = 2;

		for (int i = 2; i < N; i++)
		{
			DP[i] = (DP[i - 1] + DP[i - 2]) % 15746;
		}

		Console.WriteLine(DP[N - 1]);
	}
}