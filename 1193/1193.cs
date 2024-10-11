#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int S = 1;
		int C = 1;
		int A, B;

		while (S < N)
		{
			C++;
			S += C;
		}

		N -= S - C;

		if (C % 2 == 1)
		{
			A = C;
			B = 1;

			while (--N > 0)
			{
				A--;
				B++;
			}
		}
		else
		{
			A = 1;
			B = C;

			while (--N > 0)
			{
				A++;
				B--;
			}
		}

		Console.WriteLine(A + "/" + B);
	}
}