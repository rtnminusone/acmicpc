#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] != 999 && T[x, y] != -1) return null;
		if (V[x, y]) return null;

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
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 999)
			{
				T[p.x, p.y] = -1;
				R++;
			}

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}

		return R != 0;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == 'X') T[i, j] = -999;
				else if (S[0][j] == '.') T[i, j] = 999;
				else if (S[0][j] == ' ') T[i, j] = -1;
				else T[i, j] = -2;
			}
		}
		int R1 = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == -2 && !V[i, j])
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
					if (BFS()) R1++;
				}
			}
		}
		int R2 = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] ==  999) R2++;
			}
		}

		Console.WriteLine(R1 + " " + R2);
	}
}