#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Numerics;

class Program
{
	public static BigInteger Factorial(int A, int N)
	{
		BigInteger R = new BigInteger(A);

		if (A < N)
		{
			int B = (A + N) / 2;
			R = Factorial(A, B) * Factorial(B + 1, N);
		}

		return R;
	}

	public static void Main()
	{
		Console.WriteLine(Factorial(1, int.Parse(Console.ReadLine())));
	}
}