#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int M;
	public static int[] T;
	public static bool[] B;
	public static StringBuilder sb = new StringBuilder();

	public static void DFS(int depth, int[] R)
	{
		if (depth == M)
		{
			sb.AppendLine(String.Join(" ", R));
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (!B[i])
			{
				R[depth] = T[i];
				B[i] = true;
				DFS(depth + 1, R);
				B[i] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N];
		B = new bool[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		Array.Sort(T);

		DFS(0, new int[M]);

		Console.WriteLine(sb);
	}
}