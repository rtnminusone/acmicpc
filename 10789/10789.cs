#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		string[,] s = new string[5, 15];
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < 5; i++)
		{
			//s[i] = Console.ReadLine().Split(' ');
			string b = Console.ReadLine();
			for (int j = 0; j < b.Length; j++)
			{
				s[i, j] = b[j] + "";
			}
		}

		for (int i = 0; i < 15; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				sb.Append(s[j, i]);
			}
		}

		Console.WriteLine(sb);
	}
}