#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split(' ');
		int[] K = new int[4];

		K[0] = int.Parse(S[0]) - 0;
		K[1] = int.Parse(S[2]) - int.Parse(S[0]);
		K[2] = int.Parse(S[1]) - 0;
		K[3] = int.Parse(S[3]) - int.Parse(S[1]);

		Array.Sort(K);

		Console.WriteLine(K[0]);
	}
}