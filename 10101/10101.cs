#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int[] X = new int[3];
		int R = 0;

		for (int i = 0; i < 3; i++)
		{
			X[i] = int.Parse(Console.ReadLine());
			R += X[i];
		}

		if (R != 180) Console.WriteLine("Error");
		else if (X[0] == X[1] && X[1] == X[2]) Console.WriteLine("Equilateral");
		else if (X[0] == X[1] || X[0] == X[2] || X[1] == X[2]) Console.WriteLine("Isosceles");
		else Console.WriteLine("Scalene");
	}
}