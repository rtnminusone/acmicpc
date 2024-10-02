#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static double cal(string s)
	{
		switch (s)
		{
			case "A+": return 4.5;
			case "A0": return 4.0;
			case "B+": return 3.5;
			case "B0": return 3.0;
			case "C+": return 2.5;
			case "C0": return 2.0;
			case "D+": return 1.5;
			case "D0": return 1.0;
			default: return 0.0;
		}
	}

	public static void Main(string[] args)
	{
		double t = 0.0;
		double g = 0.0;

		for (int i = 0; i < 20; i++)
		{
			string[] s = Console.ReadLine().Split(' ');

			if (s[2] != "P")
			{
				t += double.Parse(s[1]);
				g += double.Parse(s[1]) * Program.cal(s[2]);
			}
		}

		Console.WriteLine(g / t);
	}
}