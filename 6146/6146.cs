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

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == X && p.y == Y) return p.w;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static int N = 1001;
	public static int X, Y;
	public static int[,] T = new int[N, N];
	public static bool[,] V = new bool[N, N];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		X = int.Parse(S[0]) + 500;
		Y = int.Parse(S[1]) + 500;
		int n = int.Parse(S[2]);
		for (int i = 0; i < n; i++)
		{
			S = Console.ReadLine().Split();
			T[int.Parse(S[0]) + 500, int.Parse(S[1]) + 500] = 1;
		}
		Push(Create(500, 500, 0));

		Console.WriteLine(BFS());
	}
}