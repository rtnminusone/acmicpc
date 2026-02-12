#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

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

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static int N, X, Y;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -2, -2, 2, 2, -1, 1, -1, 1 };
	public static int[] dy = { -1, 1, -1, 1, -2, -2, 2, 2 };

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		for (int i = 1; i <= t; i++)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			T = new int[N, N];
			V = new bool[N, N];
			Q.Clear();
			X = int.Parse(S[3]) - 1;
			Y = int.Parse(S[4]) - 1;

			Push(Create(int.Parse(S[1]) - 1, int.Parse(S[2]) - 1, 0));

			sb.AppendLine("Case #" + i + ": " + BFS());
			sb.AppendLine();
		}

		Console.WriteLine(sb.ToString());
	}
}