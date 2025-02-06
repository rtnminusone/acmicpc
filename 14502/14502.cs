#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

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
	public static int M;
	public static int[,] T;
	public static bool[,] V;
	public static List<Pos> P = new List<Pos>();
	public static List<int> L = new List<int>();
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void DFS(int depth, int start)
	{
		if (depth == 3)
		{
			L.Add(BFS(new Queue<Pos>(Q), (bool[,])V.Clone()));
			return;
		}

		for (int i = start; i < P.Count; i++)
		{
			if (!V[P[i].x, P[i].y])
			{
				V[P[i].x, P[i].y] = true;
				DFS(depth + 1, i);
				V[P[i].x, P[i].y] = false;
			}
		}
	}

	public static int BFS(Queue<Pos> q, bool[,] v)
	{
		int R = 0;

		while (q.Count != 0)
		{
			Pos p = q.Dequeue();

			Push(q, v, Create(p.x - 1, p.y, v));
			Push(q, v, Create(p.x + 1, p.y, v));
			Push(q, v, Create(p.x, p.y - 1, v));
			Push(q, v, Create(p.x, p.y + 1, v));
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (!v[i, j]) R++;
			}
		}

		return R;
	}

	public static Pos Create(int x, int y, bool[,] v)
	{
		if (x < 0 || y < 0 || x >= N || y >= M || v[x, y]) return null;

		if (T[x, y] != 0)
		{
			v[x, y] = true;
			return null;
		}

		return new Pos(x, y);
	}

	public static bool Push(Queue<Pos> q, bool[,] v, Pos p)
	{
		if (p == null) return false;

		q.Enqueue(p);
		v[p.x, p.y] = true;

		return true;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		T = new int[N, M];
		V = new bool[N, M];

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] == 2)
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
				}
				else if (T[i, j] == 0)
				{
					P.Add(new Pos(i, j));
				}
				else V[i, j] = true;
			}
		}

		DFS(0, 0);

		L.Sort();

		Console.WriteLine(L[L.Count - 1]);
	}
}