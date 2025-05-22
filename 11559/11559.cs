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

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= 12 || y < 0 || y >= 6) return null;
		if (T[x, y] == 0 || V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static bool BFS()
	{
		bool R = false;
		List<Pos> L = new List<Pos>();

		while (Q.Count != 0)
		{
			Pos q = Q.Dequeue();
			L.Add(q);

			for (int i = 0; i < 4; i++)
			{
				Pos p = Create(q.x + dx[i], q.y + dy[i]);
				if (p != null)
				{
					if (T[q.x, q.y] == T[p.x, p.y]) Push(p);
				} 
			}
		}

		if (L.Count >= 4)
		{
			foreach (Pos p in L)
			{
				T[p.x, p.y] = 0;
			}
			R = true;
		}

		return R;
	}

	public static void Gravity()
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				if (T[j, i] == 0)
				{
					for (int k = j + 1; k < 12; k++)
					{
						if (T[k, i] != 0)
						{
							T[j, i] = T[k, i];
							T[k, i] = 0;
							break;
						}
					}
				}
			}
		}
	}

	public static int[,] T = new int[12, 6];
	public static bool[,] V = new bool[12, 6];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		for (int i = 11; i >= 0; i--)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < 6; j++)
			{
				if (S[j] == '.') T[i, j] = 0;
				else if (S[j] == 'R') T[i, j] = 1;
				else if (S[j] == 'G') T[i, j] = 2;
				else if (S[j] == 'B') T[i, j] = 3;
				else if (S[j] == 'P') T[i, j] = 4;
				else T[i, j] = 5;
			}
		}

		int R = 0;
		while (true)
		{
			int r = 0;
			V = new bool[12, 6];
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (T[i, j] != 0)
					{
						Push(Create(i, j));
						if (BFS()) r = 1;
					}
				}
			}
			if (r == 1)
			{
				R++;
				Gravity();
			}
			else break;
		}

		Console.WriteLine(R);
	}
}