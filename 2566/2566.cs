#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		int[] p = new int[2]{ 1, 1 };
		int r = 0;

		for (int i = 0; i < 9; i++)
		{
			string[] b = Console.ReadLine().Split(' ');

			for (int j = 0; j < 9; j++)
			{
				if (r < int.Parse(b[j]))
				{
					r = int.Parse(b[j]);
					p[0] = i + 1;
					p[1] = j + 1;
				}
			}
		}

		Console.WriteLine(r);
		Console.WriteLine(p[0] + " " + p[1]);
	}
}