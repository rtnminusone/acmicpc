#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int W;
	public static int H;
	public static int R;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static StringBuilder sb = new StringBuilder();

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

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= H || y >= W) return null;
		if (T[x, y] == 0) return null;
		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null || V[pos.x, pos.y]) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static void BFS()
	{
		for (int i = 0; i < H; i++)
		{
			for (int j = 0; j < W; j++)
			{
				if (T[i, j] == 1 && !V[i, j])
				{
					if (Push(Create(i, j)))
					{
						Simulation();
						R++;
					}
				}
			}
		}

		sb.AppendLine(R + "");
	}

	public static void Simulation()
	{
		while (Q.Count != 0)
		{
			Pos pos = Q.Dequeue();

			Push(Create(pos.x - 1, pos.y - 1));
			Push(Create(pos.x - 1, pos.y));
			Push(Create(pos.x - 1, pos.y + 1));
			Push(Create(pos.x, pos.y - 1));
			Push(Create(pos.x, pos.y + 1));
			Push(Create(pos.x + 1, pos.y - 1));
			Push(Create(pos.x + 1, pos.y));
			Push(Create(pos.x + 1, pos.y + 1));
		}
	}

	public static void Main(string[] args)
	{
		while (true)
		{
			string[] S = Console.ReadLine().Split();
			W = int.Parse(S[0]);
			H = int.Parse(S[1]);

			if (W == 0 && H == 0) break;

			R = 0;
			T = new int[H, W];
			V = new bool[H, W];
			Q = new Queue<Pos>();

			for (int i = 0; i < H; i++)
			{
				S = Console.ReadLine().Split();
				for (int j = 0; j < W; j++)
				{
					T[i, j] = int.Parse(S[j]);
				}
			}

			BFS();
		}

		Console.WriteLine(sb);
	}
}