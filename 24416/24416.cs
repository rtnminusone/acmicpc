#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;

class Program
{
	public static int count_rec = 0;
	public static int count_loop = 0;

	public static int Fib_Rec(int n)
	{
		if (n == 1 || n == 2)
		{
			count_rec++;
			return 1;
		}
		else return Fib_Rec(n - 1) + Fib_Rec(n - 2);
	}

	public static int Fib_Loop(int n)
	{
		if (n < 3) return 1;
		int[] result = new int[n];
		Array.Fill(result, 1);

		for (int i = 2; i < n; i++)
		{
			count_loop++;
			result[i] = result[i - 1] + result[i - 2];
		}

		return result[n - 1];
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());

		Fib_Rec(N);
		Fib_Loop(N);

		Console.WriteLine(count_rec + " " + count_loop);
	}
}