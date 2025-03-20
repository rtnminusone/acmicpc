#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Ans
	{
		public int x;
		public int w;

		public Ans(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static int N;
	public static int[] T;
	public static bool[] V;
	public static Queue<Ans> Q;

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Ans q = Q.Dequeue();

			if (q.x == N - 1) return q.w;

			for (int i = 1; i <= T[q.x]; i++)
			{
				if (q.x + i < N && !V[q.x + i])
				{
					Q.Enqueue(new Ans(q.x + i, q.w + 1));
					V[q.x + i] = true;
				}
			}
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		V = new bool[N];
		Q = new Queue<Ans>();

		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		Q.Enqueue(new Ans(0, 0));
		V[0] = true;

		Console.WriteLine(BFS());
	}
}