#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;

class Program
{
	public class Pos
	{
		public int x;
		public int y;
		public int w;

		public Pos(int x, int y, int w)
		{
			this.x = x;
			this.y = y;
			this.w = w;
		}

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.w = 0;
		}
	}

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (T[x, y] == 1) return null;
		if (V[x, y]) return null;

		return new Pos(x, y, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static int BFS(Pos Goal)
	{
		List<Pos> D = new List<Pos>();

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (Goal == null)
			{
				if (D.Count != 0 && D[0].w < p.w) continue;

				for (int i = 0; i < L1.Count; i++)
				{
					if (Compare(p, L1[i]))
					{
						D.Add(p);
						break;
					}
				}
			}
			else
			{
				if (Compare(p, Goal))
				{
					start = p;

					return p.w;
				}
			}

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		if (D.Count != 0)
		{
			var r = D.OrderBy(a => a.x).ThenBy(b => b.y).ToList();
			for (int i = 0; i < L1.Count; i++)
			{
				if (Compare(r[0], L1[i]))
				{
					start = L1[i];
					goal = L2[i];
					L1.RemoveAt(i);
					L2.RemoveAt(i);

					return r[0].w;
				}
			}
		}

		return -1;
	}

	public static bool Compare(Pos p1, Pos p2)
	{
		if (p1.x == p2.x && p1.y == p2.y) return true;

		return false;
	}

	public static int Find()
	{
		Q = new Queue<Pos>();
		V = new bool[N, N];
		start.w = 0;
		Push(start);

		return BFS(null);
	}

	public static int Search()
	{
		Q = new Queue<Pos>();
		V = new bool[N, N];
		start.w = 0;
		Push(start);

		return BFS(goal);
	}

	public static int N, M, F;
	public static int[,] T;
	public static bool[,] V;
	public static Pos start, goal;
	public static Queue<Pos> Q;
	public static List<Pos> L1 = new List<Pos>();
	public static List<Pos> L2 = new List<Pos>();

	public static int[] dx = { -1, 0, 0, 1 };
	public static int[] dy = { 0, -1, 1, 0 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		F = int.Parse(S[2]);
		T = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}
		S = Console.ReadLine().Split();
		start = new Pos(int.Parse(S[0]) - 1, int.Parse(S[1]) - 1);
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L1.Add(new Pos(int.Parse(S[0]) - 1, int.Parse(S[1]) - 1));
			L2.Add(new Pos(int.Parse(S[2]) - 1, int.Parse(S[3]) - 1));
		}

		int R = 0;
		for (int i = 0; i < M; i++)
		{
			R = Find();
			if (R == -1 || F - R < 0)
			{
				Console.WriteLine(-1);
				return;
			}
			F -= R;
			R = Search();
			if (R == -1 || F - R < 0)
			{
				Console.WriteLine(-1);
				return;
			}
			F += R;
		}

		Console.WriteLine(F);
	}
}