#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int[] X = new int[3];

		while (true)
		{
			string[] S = Console.ReadLine().Split(' ');

			if (int.Parse(S[0]) == 0) break;

			X[0] = int.Parse(S[0]);
			X[1] = int.Parse(S[1]);
			X[2] = int.Parse(S[2]);

			Array.Sort(X);

			if (X[0] + X[1] <= X[2]) sb.AppendLine("Invalid");
			else if (X[0] == X[1] && X[1] == X[2]) sb.AppendLine("Equilateral");
			else if (X[0] == X[1] || X[0] == X[2] || X[1] == X[2]) sb.AppendLine("Isosceles");
			else sb.AppendLine("Scalene");
		}

		Console.WriteLine(sb);
	}
}