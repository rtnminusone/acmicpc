#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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
	}

	public static Pos Create(int x, int y, int w)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
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

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1 && p.y == M - 1) return p.w.ToString();

			Push(Create(p.x - T[p.x, p.y], p.y, p.w + 1));
			Push(Create(p.x + T[p.x, p.y], p.y, p.w + 1));
			Push(Create(p.x, p.y - T[p.x, p.y], p.w + 1));
			Push(Create(p.x, p.y + T[p.x, p.y], p.w + 1));
		}

		return "IMPOSSIBLE";
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

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
				T[i, j] = S[0][j] - '0';
			}
		}

		Push(Create(0, 0, 0));

		Console.WriteLine(BFS());
	}
}