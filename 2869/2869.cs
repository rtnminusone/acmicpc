#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split(' ');

		long A = long.Parse(S[0]);
		long B = long.Parse(S[1]);
		long V = long.Parse(S[2]);

		double R;

		if ((V - B) % (A - B) == 0) R = (V - B) / (A - B);
		else R = (V - B) / (A - B) + 1;

		Console.WriteLine(R);
	}
}