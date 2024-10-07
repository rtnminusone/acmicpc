#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static long power(int c, int pow)
	{
		long r = 1;

		for (int i = 0; i < pow; i++)
		{
			r *= c;
		}

		return r;
	}

	public static void Main(string[] args)
	{
		string[] s = Console.ReadLine().Split(' ');
		int B = int.Parse(s[1]);
		long R = 0;
		int pow = 0;

		for (int i = s[0].Length - 1; i >= 0; i--)
		{
			if (0 <= s[0][i] - '0' && s[0][i] - '0' <= 9) R += (s[0][i] - '0') * power(B, pow++);
			else R += (s[0][i] - '7') * power(B, pow++);
		}

		Console.WriteLine(R);
	}
}