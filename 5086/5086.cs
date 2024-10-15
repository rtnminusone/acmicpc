#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split(' ');
			int A = int.Parse(S[0]);
			int B = int.Parse(S[1]);

			if (A == 0 && B == 0) break;

			if (A % B == 0) sb.AppendLine("multiple");
			else if (B % A == 0) sb.AppendLine("factor");
			else sb.AppendLine("neither");
		}

		Console.WriteLine(sb);
	}
}