#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public struct Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N, M;
	public static char[,] T;
	public static bool[,] V, V2;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static Queue<(Pos, int)> Q2 = new Queue<(Pos, int)>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void LabelBFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 'X')
			{
				Q2.Enqueue((p, 0));
				V2[p.x, p.y] = true;
			}

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (!V[pos.x, pos.y] && T[pos.x, pos.y] == 'X')
					{
						Q.Enqueue(pos);
						V[pos.x, pos.y] = true;
					}
				}
			}
		}
	}

	public static int BFS()
	{
		while (Q2.Count > 0)
		{
			var (p, w) = Q2.Dequeue();

			if (T[p.x, p.y] == 'X' && w != 0) return w - 1;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (!V2[pos.x, pos.y])
					{
						Q2.Enqueue((pos, w + 1));
						V2[pos.x, pos.y] = true;
					}
				}
			}
		}

		return -1;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new char[N, M];
		V = new bool[N, M];
		V2 = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j];
				if (Q.Count == 0 && T[i, j] == 'X')
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
				}
			}
		}

		LabelBFS();

		Console.WriteLine(BFS());
	}
}