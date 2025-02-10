#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public static int F;
	public static int G;
	public static int U;
	public static int D;
	public static bool[] V;
	public static Queue<Pos> Q = new Queue<Pos>();

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

	public static int BFS()
	{
		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == G) return p.y;

			if (p.x + U <= F && !V[p.x + U - 1])
			{
				Q.Enqueue(new Pos(p.x + U, p.y + 1));
				V[p.x + U - 1] = true;
			}
			if (p.x - D > 0 && !V[p.x - D - 1])
			{
				Q.Enqueue(new Pos(p.x - D, p.y + 1));
				V[p.x - D - 1] = true;
			}
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		F = int.Parse(S[0]);
		int start = int.Parse(S[1]);
		G = int.Parse(S[2]);
		U = int.Parse(S[3]);
		D = int.Parse(S[4]);
		V = new bool[F];

		Q.Enqueue(new Pos(start, 0));
		V[start - 1] = true;
		int R = BFS();

		if (R == -1) Console.WriteLine("use the stairs");
		else Console.WriteLine(R);
	}
}