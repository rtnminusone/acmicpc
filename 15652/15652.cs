#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int N;
	public static int K;
	public static StringBuilder sb = new StringBuilder();

	public static void back_tracking(int depth, int[] result, bool[,] visited)
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
			else i = result[depth - 1];
			for (; i <= N; i++)
			{
				if (!visited[depth, i])
				{
					result[depth] = i;
					visited[depth, i] = true;
					back_tracking(depth + 1, result, visited);
					visited[depth, i] = false;
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split(' ');
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		bool[,] visited = new bool[K, N + 1];
		int[] result = new int[K];
		Array.Clear(visited, 0, visited.Length);
		Array.Fill(result, 0);

		back_tracking(0, result, visited);

		Console.WriteLine(sb);
	}
}