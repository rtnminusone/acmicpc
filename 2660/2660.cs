#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int x;
		public int w;

		public Pos(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static Pos Create(int start, int x, int w)
	{
		if (V[start, x]) return null;
		if (start == x) return null;

		return new Pos(x, w);
	}

	public static bool Push(int start, Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[start, pos.x] = true;

		return true;
	}

	public static int BFS(int start)
	{
		int R = -1;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			T[start, p.x] = p.w;
			if (R < p.w) R = p.w;

			foreach (var v in L[p.x])
			{
				Push(start, Create(start, v, p.w + 1));
			}
		}

		return R;
	}

	public static int N;
	public static int U = int.MaxValue;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static List<int>[] L;

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		V = new bool[N, N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			int A = int.Parse(S[0]);
			int B = int.Parse(S[1]);
			if (A == -1 && B == -1) break;

			L[A - 1].Add(B - 1);
			L[B - 1].Add(A - 1);
		}

		List<int> Ans = new List<int>();
		for (int i = 0; i < N; i++)
		{
			Q = new Queue<Pos>();
			foreach (var v in L[i])
			{
				Push(i, Create(i, v, 1));
			}

			int r = BFS(i);
			if (r == -1) continue;
			if (r < U)
			{
				U = r;
				Ans = new List<int>();
				Ans.Add(i + 1);
			}
			else if (r == U) Ans.Add(i + 1);
		}

		sb.AppendLine(U + " " + Ans.Count);
		foreach (var v in Ans)
		{
			sb.Append(v + " ");
		}
		Console.WriteLine(sb);
	}
}