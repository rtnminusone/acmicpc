﻿#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static int C = 1;
	public static int[] R;
	public static bool[] V;
	public static List<int>[] L;

	public static void DFS(int depth, int start)
	{
		if (depth == N) return;

		if (R[start - 1] == 0)
		{
			R[start - 1] = C++;
			V[start - 1] = true;
		}

		foreach (int l in L[start - 1])
		{
			if (!V[l - 1]) DFS(depth + 1, l);
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		R = new int[N];
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
			L[i].Reverse();
		}

		DFS(0, K);

		Console.WriteLine(String.Join("\n", R));
	}
}