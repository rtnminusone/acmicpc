#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;

class Program
{
	public class Pos
	{
		public int disp;
		public int clip;
		public int cost;

		public Pos(int disp, int clip, int cost)
		{
			this.disp = disp;
			this.clip = clip;
			this.cost = cost;
		}
	}

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.disp == N) return p.cost;

			if (p.disp <= N && !V[p.disp, p.disp])
			{
				Q.Enqueue(new Pos(p.disp, p.disp, p.cost + 1));
				V[p.disp, p.disp] = true;
			}
			if (p.clip != 0 && p.disp + p.clip <= N && !V[p.disp + p.clip, p.clip])
			{
				Q.Enqueue(new Pos(p.disp + p.clip, p.clip, p.cost + 1));
				V[p.disp + p.clip, p.clip] = true;
			}
			if (p.disp != 0 && !V[p.disp - 1, p.clip])
			{
				Q.Enqueue(new Pos(p.disp - 1, p.clip, p.cost + 1));
				V[p.disp - 1, p.clip] = true;
			}
		}

		return -1;
	}

	public static int N;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N + 1, N + 1];

		Q.Enqueue(new Pos(1, 0, 0));
		V[1, 0] = true;

		Console.WriteLine(BFS());
	}
}