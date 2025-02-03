#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int M;
	public static int R = 1;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;

	public static void DFS(int D)
	{
		if (!V[D - 1])
		{
			T[D - 1] = R++;
			V[D - 1] = true;

			foreach (int l in L[D - 1])
			{
				DFS(l);
			}
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);
		T = new int[N];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]));
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]));
		}

		for (int i = 0; i < N; i++)
		{
			L[i].Sort();
		}

		DFS(K);

		for (int i = 0; i < N; i++)
		{
			sb.AppendLine(T[i] + "");
		}

		Console.WriteLine(sb);
	}
}