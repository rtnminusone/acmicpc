#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int[] A = new int[3];
		int[] B = new int[3];
		int X, Y;

		string[] S = Console.ReadLine().Split(' ');
		A[0] = int.Parse(S[0]);
		B[0] = int.Parse(S[1]);
		S = Console.ReadLine().Split(' ');
		A[1] = int.Parse(S[0]);
		B[1] = int.Parse(S[1]);
		S = Console.ReadLine().Split(' ');
		A[2] = int.Parse(S[0]);
		B[2] = int.Parse(S[1]);

		if (A[0] == A[1]) X = A[2];
		else if (A[0] == A[2]) X = A[1];
		else X = A[0];

		if (B[0] == B[1]) Y = B[2];
		else if (B[0] == B[2]) Y = B[1];
		else Y = B[0];

		Console.WriteLine(X + " " + Y);
	}
}