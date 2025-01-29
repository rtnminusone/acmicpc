#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int M;
	public static List<int>[] L;
	public static Queue<int> Q;
	public static bool[] B;

	public static int BFS(int goal)
	{
		int[] R = new int[N];

		while (Q.Count != 0)
		{
			int P = Q.Dequeue();

			foreach (int l in L[P])
			{
				if (l == goal) return R[P] + 1;
				if (!B[l])
				{
					Q.Enqueue(l);
					B[l] = true;
					R[l] = R[P] + 1;
				}
			}
		}

		return int.MaxValue;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		L = new List<int>[N];

		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int A = int.Parse(S[0]);
			int B = int.Parse(S[1]);

			L[A - 1].Add(B - 1);
			L[B - 1].Add(A - 1);
		}

		int Min = int.MaxValue;
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			int Sum = 0;

			for (int j = 0; j < N; j++)
			{
				if (i == j) continue;
				Q = new Queue<int>();
				B = new bool[N];
				Q.Enqueue(i);
				B[i] = true;
				Sum += BFS(j); 
			}

			if (Sum < Min)
			{
				Min = Sum;
				R = i + 1;
			}
		}

		Console.WriteLine(R);
	}
}