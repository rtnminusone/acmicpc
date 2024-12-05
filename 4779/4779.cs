#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void k_sort(char[] A, int p, int r)
	{
		int q = (r - p + 1) / 3;
		if (q == 1)
		{
			A[p] = '-';
			A[r] = '-';
			return;
		}
		else
		{
			k_sort(A, p, p + q - 1);
			k_sort(A, r - q + 1, r);
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string S = Console.ReadLine();

		while (S != null)
		{
			int N = int.Parse(S);
			if (N == 0) sb.AppendLine("-");
			else
			{
				char[] A = new char[(int)Math.Pow(3, N)];
				Array.Fill(A, ' ');

				k_sort(A, 0, A.Length - 1);

				sb.AppendLine(new string(A));
			}
			S = Console.ReadLine();
		}

		Console.WriteLine(sb);
	}
}