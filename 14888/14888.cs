#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int K;
	public static int cnt = 0;
	public static int[] V;
	public static int[] R;
	public static int[] C = new int[4];

	public static int CalculatePermutations()
	{
		long numerator = Factorial(N - 1);
		long denominator = 1;

		foreach (int count in C)
		{
			denominator *= Factorial(count);
		}

		return (int)(numerator / denominator);
	}

	public static long Factorial(int n)
	{
		long result = 1;

		for (int i = 2; i <= n; i++)
		{
			result *= i;
		}

		return result;
	}

	public static void back_tracking(int depth, int result)
	{
		if (depth == N - 1) R[cnt++] = result;
		else
		{
			int bkup = result;
			if (C[0] > 0)
			{
				C[0]--;
				result += V[depth + 1];
				back_tracking(depth + 1, result);
				C[0]++;
				result = bkup;
			}
			if (C[1] > 0)
			{
				C[1]--;
				result -= V[depth + 1];
				back_tracking(depth + 1, result);
				C[1]++;
				result = bkup;
			}
			if (C[2] > 0)
			{
				C[2]--;
				result *= V[depth + 1];
				back_tracking(depth + 1, result);
				C[2]++;
				result = bkup;
			}
			if (C[3] > 0)
			{
				C[3]--;
				result /= V[depth + 1];
				back_tracking(depth + 1, result);
				C[3]++;
				result = bkup;
			}
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		V = new int[N];
		string[] S = Console.ReadLine().Split(' ');

		for (int i = 0; i < N; i++)
		{
			V[i] = int.Parse(S[i]);
		}

		S = Console.ReadLine().Split(' ');

		for (int i = 0; i < 4; i++)
		{
			C[i] = int.Parse(S[i]);
		}

		K = CalculatePermutations();
		R = new int[K];

		back_tracking(0, V[0]);

		Array.Sort(R);

		Console.WriteLine(R[K - 1]+ "\n" + R[0]);
	}
}