#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		int K = 1;
		int C = 1;

		while (K < N)
		{
			K += C * 6;
			C++;
		}

		Console.WriteLine(C);
	}
}