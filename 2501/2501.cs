#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split(' ');
		int A = int.Parse(S[0]);
		int B = int.Parse(S[1]);
		int[] K = new int[B];
		int j = 0;

		for (int i = 1; i <= A; i++)
		{
			if (A % i == 0)
			{
				if (j == B) break;
				K[j++] = i;
			}
		}

		Console.WriteLine(K[B - 1]);
	}
}