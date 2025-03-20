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

	public static int A;
	public static int K;
	public static bool[] V;
	public static Queue<Ans> Q = new Queue<Ans>();

	public static int BFS()
	{
		int R = int.MaxValue;

		while (Q.Count != 0)
		{
			Ans a = Q.Dequeue();

			if (a.x == K) return a.w;

			if (a.x * 2 <= K && !V[a.x * 2 - 1])
			{
				V[a.x * 2 - 1] = true;
				Q.Enqueue(new Ans(a.x * 2, a.w + 1));
			}
			if (a.x + 1 <= K && !V[a.x])
			{
				V[a.x] = true;
				Q.Enqueue(new Ans(a.x + 1, a.w + 1));
			}
		}

		return R;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		A = int.Parse(S[0]);
		K = int.Parse(S[1]);
		V = new bool[K];

		V[A - 1] = true;
		Q.Enqueue(new Ans(A, 0));

		Console.WriteLine(BFS());
	}
}