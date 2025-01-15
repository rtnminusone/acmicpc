#pragma warning disable CS8600, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N;
	public static int C = 0;
	public static int[, ] T;
	public static bool[, ] V;
	public static List<int> L = new List<int>();
	public static Queue<Pos> Q = new Queue<Pos>();

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= N) return null;
		return new Pos(x, y);
	}

	public static bool Check(Pos pos)
	{
		if (pos == null) return false;
		if (T[pos.x, pos.y] == 0 || V[pos.x, pos.y]) return false;
		return true;
	}

	public static void Input(Pos pos)
	{
		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;
	}

	public static void BFS()
	{
		C = 0;
		while (Q.Count != 0)
		{
			var E = Q.Dequeue();
			if (Check(Create(E.x - 1, E.y))) Input(new Pos(E.x - 1, E.y));
			if (Check(Create(E.x + 1, E.y))) Input(new Pos(E.x + 1, E.y));
			if (Check(Create(E.x, E.y - 1))) Input(new Pos(E.x, E.y - 1));
			if (Check(Create(E.x, E.y + 1))) Input(new Pos(E.x, E.y + 1));
			C++;
		}
		L.Add(C);
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		V = new bool[N, N];
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = S[j] - '0';
			}
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (T[i, j] != 0 && !V[i, j])
				{
					Input(new Pos(i, j));
					BFS();
				}
			}
		}

		L.Sort();

		sb.AppendLine(L.Count + "");
		foreach (var l in L)
		{
			sb.AppendLine(l + "");
		}

		Console.WriteLine(sb);
	}
}