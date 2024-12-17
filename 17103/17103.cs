#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static bool[] B = new bool[1000000];
	public static List<int> L = new List<int>();
	public static int C = 0;

	public static void init()
	{
		for (int i = 2; i * i <= 1000000; i++)
		{
			if (!B[i - 1])
			{
				for (int j = i * i; j <= 1000000; j += i)
				{
					B[j - 1] = true;
				}
			}
		}
		for (int i = 1; i < 1000000; i++)
		{
			if (!B[i]) L.Add(i + 1);
		}
	}

	public static void two_pointer(int goal, int left, int right)
	{
		C = 0;

		while (left <= right)
		{
			int sum = L[left] + L[right];

			if (sum == goal)
			{
				C++;
				left++;
				right--;
			}
			else if (sum < goal) left++;
			else right--;
		}
	}

	public static void Main(string[] args)
	{
		init();

		StringBuilder sb = new StringBuilder();
		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			two_pointer(int.Parse(Console.ReadLine()), 0, L.Count - 1);
			sb.AppendLine(C + "");
		}

		Console.WriteLine(sb);
	}
}