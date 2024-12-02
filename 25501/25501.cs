#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int count;

	public static int recursion(string s, int l, int r)
	{
		count++;
		if (l >= r) return 1;
		else if (s[l] != s[r]) return 0;
		else return recursion(s, l + 1, r - 1);
	}

	public static int isPalindrome(string s)
	{
		count = 0;
		return recursion(s, 0, s.Length - 1);
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			sb.AppendLine(isPalindrome(Console.ReadLine()) + " " + count);
		}

		Console.WriteLine(sb);
	}
}