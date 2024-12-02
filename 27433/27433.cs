#pragma warning disable CS8600, CS8602, CS8604

using System;

class Program
{
	public static long F(int K)
	{
		if (K == 1) return 1;
		return K * F(K - 1);
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());

		if (N == 0) Console.WriteLine(1 + "");
		else Console.WriteLine(F(N) + "");
	}
}