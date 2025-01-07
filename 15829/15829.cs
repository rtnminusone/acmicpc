#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Numerics;

class Program
{
	public static int Pow(int C)
	{
		BigInteger N = 1;

		for (int i = 1; i <= C; i++)
		{
			N = (N * 31) % 1234567891;
		}

		return (int)N;
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		string S = Console.ReadLine();
		BigInteger SUM = 0;

		for (int i = 0; i < S.Length; i++)
		{
			BigInteger K = S[i] - 'a' + 1;
			SUM += (K * Pow(i)) % 1234567891; 
		}

		Console.WriteLine(SUM % 1234567891);
	}
}