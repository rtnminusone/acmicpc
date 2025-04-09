#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int N;
	public static int[] T;
	public static bool[] V;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			int q = Q.Dequeue();
			R++;

			if (0 <= q - T[q - 1] - 1 && !V[q - T[q - 1] - 1])
			{
				Q.Enqueue(q - T[q - 1]);
				V[q - T[q - 1] - 1] = true;
			}
			if (q + T[q - 1] - 1 < N && !V[q + T[q - 1] - 1])
			{
				Q.Enqueue(q + T[q - 1]);
				V[q + T[q - 1] - 1] = true;
			}
		}

		return R;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		V = new bool[N];

		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		int K = int.Parse(Console.ReadLine());

		V[K - 1] = true;
		Q.Enqueue(K);

		Console.WriteLine(BFS());
	}
}