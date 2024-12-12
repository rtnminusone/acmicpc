#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int[,] P;
	public static List<int> L = new List<int>();
	public static bool[] visited;

	public static int CalculateResult()
	{
		int result1 = 0, result2 = 0;

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (visited[i] && visited[j]) result1 += P[i, j];
				else if (!visited[i] && !visited[j]) result2 += P[i, j];
			}
		}

		return Math.Abs(result1 - result2);
	}

	public static void back_tracking(int depth, int n)
	{
		if (depth > N / 2 - 1)
		{
			L.Add(CalculateResult());
		}
		else
		{
			for (int i = n + 1; i < N; i++)
			{
				if (!visited[i])
				{
					visited[i] = true;
					back_tracking(depth + 1, i);
					visited[i] = false;
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		P = new int[N, N];

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split(' ');
			for (int j = 0; j < N; j++)
			{
				P[i, j] = int.Parse(S[j]);
			}
		}

		visited = new bool[N];

		back_tracking(0, -1);

		L.Sort();

		Console.WriteLine(L[0]);
	}
}