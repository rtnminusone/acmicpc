#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int M;
	public static string[] S;
	public static bool[] V;
	public static StringBuilder sb = new StringBuilder();

	public static void DFS(int depth, int start, StringBuilder str)
	{
		if (depth == M)
		{
			bool F = false;
			int C = 0;
			for (int i = 0; i < depth; i++)
			{
				if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u') F = true;
				else C++;
			}

			if (F && C >= 2) sb.AppendLine(str.ToString());

			return;
		}

		for (int i = start; i < N; i++)
		{
			if (!V[i])
			{
				V[i] = true;
				str.Append(S[i]);
				DFS(depth + 1, i, str);
				str.Length--;
				V[i] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		V = new bool[N];

		S = Console.ReadLine().Split();
		Array.Sort(S);

		DFS(0, 0, new StringBuilder());

		Console.WriteLine(sb);
	}
}