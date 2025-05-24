#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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

	public static Pos Create(int start, int goal, int w)
	{
		if (V[goal]) return null;

		return new Pos(goal, w + T[start, goal]);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x] = true;

		return true;
	}

	public static int BFS(int goal)
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal) return p.w;

			foreach (int l in L[p.x])
			{
				Push(Create(p.x, l, p.w));
			}
		}

		return -1;
	}

	public static int N, M;
	public static int[,] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<Pos> Q;

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}
		for (int i = 0; i < N - 1; i++)
		{
			S = Console.ReadLine().Split();
			T[int.Parse(S[0]) - 1, int.Parse(S[1]) - 1] = int.Parse(S[2]);
			T[int.Parse(S[1]) - 1, int.Parse(S[0]) - 1] = int.Parse(S[2]);
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]) - 1);
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]) - 1);
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			V = new bool[N];
			Q = new Queue<Pos>();
			Push(Create(int.Parse(S[0]) - 1, int.Parse(S[0]) - 1, 0));
			sb.AppendLine(BFS(int.Parse(S[1]) - 1) + "");
		}

		Console.WriteLine(sb);
	}
}