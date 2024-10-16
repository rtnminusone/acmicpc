#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int N = int.Parse(Console.ReadLine());
		int K = 2;

		while (N != 1 && N >= K)
		{
			if (N % K == 0)
			{
				sb.AppendLine(K + "");
				N /= K;
			}
			else K++;
		}

		Console.WriteLine(sb);
	}
}