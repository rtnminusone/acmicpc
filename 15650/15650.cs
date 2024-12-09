#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int N;
	public static int K;
	public static StringBuilder sb = new StringBuilder();

	public static void back_tracking(int depth, int[] result, bool[] visited)
	{
		if (depth == K)
		{
			sb.AppendLine(string.Join(" ", result));
			return;
		}
		else
		{
			int i;
			if (depth == 0) i = 1;
			else i = result[depth - 1] + 1;
			for (; i <= N; i++)
			{
				if (!visited[i])
				{
					result[depth] = i;
					visited[i] = true;
					back_tracking(depth + 1, result, visited);
					visited[i] = false;
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split(' ');
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		bool[] visited = new bool[N + 1];
		int[] result = new int[K];
		Array.Fill(visited, false);
		Array.Fill(result, 0);

		back_tracking(0, result, visited);

		Console.WriteLine(sb);
	}
}