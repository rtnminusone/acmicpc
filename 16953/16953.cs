#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static long A;
	public static long B;
	public static long R = -1;

	public static void DFS(int depth, long current)
	{
		if (current == B)
		{
			if (R > depth || R == -1) R = depth + 1;
			return;
		}
		if (current > B) return;

		DFS(depth + 1, current * 2);
		DFS(depth + 1, current * 10 + 1);
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		A = long.Parse(S[0]);
		B = long.Parse(S[1]);

		DFS(0, A);

		Console.WriteLine(R);
	}
}