#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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
		if (x < 0 || x >= N || y < 0 || y >= M) return null;

		return new Pos(x, y);
	}

	public static void BFS()
	{
		while (DQ.Count > 0)
		{
			Pos p = DQ.First.Value;
			DQ.RemoveFirst();

			for (int i = 0; i < 4; i++)
			{
				Pos t = Create(p.x + dx[i], p.y + dy[i]);
				if (t != null)
				{
					if (V[t.x, t.y] > V[p.x, p.y] + T[t.x, t.y])
					{
						V[t.x, t.y] = V[p.x, p.y] + T[t.x, t.y];
						if (T[t.x, t.y] == 0) DQ.AddFirst(t);
						else DQ.AddLast(t);
					}
				}
			}
		}
	}

	public static int N, M;
	public static int[,] T, V;
	public static LinkedList<Pos> DQ = new LinkedList<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		M = int.Parse(S[0]);
		N = int.Parse(S[1]);
		T = new int[N, M];
		V = new int[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
				V[i, j] = int.MaxValue;
			}
		}

		V[0, 0] = 0;
		DQ.AddFirst(Create(0, 0));
		BFS();

		Console.WriteLine(V[N - 1, M - 1]);
	}
}