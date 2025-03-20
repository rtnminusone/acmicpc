#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int[,] T = new int[5, 5];
	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static void DFS(int depth, int x, int y, int t)
	{
		if (depth == 6)
		{
			if (!D.ContainsKey(t)) D[t] = 1;
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (x + dx[i] < 0 || x + dx[i] >= 5 || y + dy[i] < 0 || y + dy[i] >= 5) continue;
			DFS(depth + 1, x + dx[i], y + dy[i], t * 10 + T[x + dx[i], y + dy[i]]);
		}
	}

	public static void Main(string[] args)
	{
		for (int i = 0; i < 5; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < 5; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				DFS(1, i, j, T[i, j]);
			}
		}

		Console.WriteLine(D.Count);
	}
}