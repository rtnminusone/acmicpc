#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N;
	public static int[,] W;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[,] D = { { -1, -2 }, { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 } };

	public static int BFS(Pos goal)
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal.x && p.y == goal.y)
			{
				R = W[p.x, p.y];
				break;
			}

			for (int i = 0; i < 8; i++)
			{
				if (Check(p.x + D[i, 0], p.y + D[i, 1]))
				{
					W[p.x + D[i, 0], p.y + D[i, 1]] = W[p.x, p.y] + 1;
					V[p.x + D[i, 0], p.y + D[i, 1]] = true;
					Q.Enqueue(new Pos(p.x + D[i, 0], p.y + D[i, 1]));
				}
			}
		}

		return R;
	}

	public static bool Check(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= N) return false;
		if (V[x, y]) return false;

		return true;
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int T = int.Parse(Console.ReadLine());

		while (T-- != 0)
		{
			N = int.Parse(Console.ReadLine());
			W = new int[N, N];
			V = new bool[N, N];
			Q = new Queue<Pos>();

			string[] S = Console.ReadLine().Split();
			Q.Enqueue(new Pos(int.Parse(S[0]), int.Parse(S[1])));
			V[int.Parse(S[0]), int.Parse(S[1])] = true;

			S = Console.ReadLine().Split();
			sb.AppendLine(BFS(new Pos(int.Parse(S[0]), int.Parse(S[1]))) + "");
		}

		Console.WriteLine(sb);
	}
}