#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int[] X = new int[N];
		int[] Y = new int[N];

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split(' ');
			X[i] = int.Parse(S[0]);
			Y[i] = int.Parse(S[1]);
		}

		Array.Sort(X);
		Array.Sort(Y);

		Console.WriteLine((X[X.Length - 1] - X[0]) * (Y[Y.Length - 1] - Y[0]));
	}
}