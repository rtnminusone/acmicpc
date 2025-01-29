#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int count { get; set; }
		public int position { get; set; }

		public Pos(int count, int position)
		{
			this.count = count;
			this.position = position;
		}
	}

	public static int[] P = new int[101];
	public static bool[] V = new bool[101];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int BFS()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();
			while (P[p.position] != 0)
			{
				p.position = P[p.position];
			}
			if (p.position == 100)
			{
				R = p.count;
				break;
			}
			for (int i = 1; i <= 6; i++)
			{
				if (p.position + i <= 100)
				{
					if (V[p.position + i]) continue;
					V[p.position + i] = true;
					Q.Enqueue(new Pos(p.count + 1, p.position + i));
				}
			}
		}

		return R;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int M = int.Parse(S[1]);

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			P[int.Parse(S[0])] = int.Parse(S[1]);
		}

		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			P[int.Parse(S[0])] = int.Parse(S[1]);
		}

		Q.Enqueue(new Pos(0, 1));
		Console.WriteLine(BFS());
	}
}