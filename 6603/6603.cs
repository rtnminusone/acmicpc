#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int[] T;
	public static int[] R;
	public static bool[] V;
	public static StringBuilder sb = new StringBuilder();

	static void DFS(int depth, int current)
	{
		if (depth == 6)
		{
			sb.AppendLine(String.Join(" ", R));
			return;
		}
		for (int i = current; i < N; i++)
		{
			if (!V[i])
			{
				V[i] = true;
				R[depth] = T[i];
				DFS(depth + 1, i);
				V[i] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		while (true)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			if (N == 0) break;
			T = new int[N];
			V = new bool[N];
			for (int i = 0; i < N; i++)
			{
				T[i] = int.Parse(S[i + 1]);
			}

			R = new int[6];
			DFS(0, 0);
			sb.Append("\n");
		}

		Console.WriteLine(sb);
	}
}