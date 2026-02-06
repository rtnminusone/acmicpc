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

	public static int N;
	public static int[,] T;
	public static int[,] V;
	public static LinkedList<Pos> DQ = new LinkedList<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= N) return null;

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

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		V = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = 1 - (S[j] - '0');
				V[i, j] = int.MaxValue;
			}
		}

		DQ.AddFirst(new Pos(0, 0));
		V[0, 0] = 0;
		BFS();

		Console.WriteLine(V[N - 1, N - 1]);
	}
}