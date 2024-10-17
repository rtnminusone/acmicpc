#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int[] X = new int[3];

		string[] S = Console.ReadLine().Split(' ');

		X[0] = int.Parse(S[0]);
		X[1] = int.Parse(S[1]);
		X[2] = int.Parse(S[2]);

		Array.Sort(X);

		if (X[0] + X[1] <= X[2]) Console.WriteLine(X[0] + X[1] + X[0] + X[1] - 1);
		else Console.WriteLine(X[0] + X[1] + X[2]);
	}
}