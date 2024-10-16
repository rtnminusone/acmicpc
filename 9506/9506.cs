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
			StringBuilder buf = new StringBuilder();
			int N = int.Parse(Console.ReadLine());
			int K = 0;

			if (N == -1) break;

			buf.Append(N + " = ");

			for (int i = 1; i < N; i++)
			{
				if (N % i == 0)
				{
					K += i;
					buf.Append(i + " + ");
				}
			}

			if (K == N)
			{
				buf.Remove(buf.Length - 2, 2);
				sb.AppendLine(buf.ToString());
			}
			else sb.AppendLine(N + " is NOT perfect.");
		}

		Console.WriteLine(sb);
	}
}