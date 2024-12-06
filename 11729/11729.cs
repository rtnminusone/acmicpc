#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int count = 0;
	public static StringBuilder sb = new StringBuilder();

	public static void hanoi(int n, int from, int mid, int to)
	{
		if (n == 1)
		{
			count++;
			sb.AppendLine(from + " " + to);
		}
		else
		{
			hanoi(n - 1, from, to, mid);
			count++;
			sb.AppendLine(from + " " + to);
			hanoi(n - 1, mid, from, to);
		}
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());

		hanoi(N, 1, 2, 3);

		Console.WriteLine(count);
		Console.WriteLine(sb);
	}
}