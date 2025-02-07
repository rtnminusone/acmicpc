#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

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
	public static int M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int BFS()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			Push(Create(p.x - 1, p.y));
			Push(Create(p.x + 1, p.y));
			Push(Create(p.x, p.y - 1));
			Push(Create(p.x, p.y + 1));

			R++;
		}

		return R;
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || y < 0 || x >= N || y >= M) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;
		if (V[pos.x, pos.y]) return false;

		V[pos.x, pos.y] = true;
		Q.Enqueue(pos);

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		int K = int.Parse(S[2]);

		T = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();

		while (K-- != 0)
		{
			S = Console.ReadLine().Split();
			int x1 = int.Parse(S[0]);
			int y1 = int.Parse(S[1]);
			int x2 = int.Parse(S[2]);
			int y2 = int.Parse(S[3]);

			for (int i = y1; i < y2; i++)
			{
				for (int j = x1; j < x2; j++)
				{
					if (T[i, j] == 0)
					{
						T[i, j] = 1;
						V[i, j] = true;
					}
				}
			}
		}

		int R = 0;
		List<int> L = new List<int>();
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 0 && !V[i, j])
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
					L.Add(BFS());
					R++;
				}
			}
		}
		L.Sort();

		Console.WriteLine(R);
		Console.WriteLine(string.Join(" ", L));
	}
}