#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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

	public static int BFS(Pos goal)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal.x && p.y == goal.y) return p.w;

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i], p.w + 1));
			}
		}

		return -1;
	}

	public static int N = 8, M = 8;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
	public static int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string line;
		while ((line = Console.ReadLine()) != null)
		{
			string[] S = line.Split();
			int a1 = S[0][0] - 'a';
			int b1 = S[0][1] - '1';
			int a2 = S[1][0] - 'a';
			int b2 = S[1][1] - '1';
			Q.Clear();
			V = new bool[N, M];
			Push(Create(a1, b1, 0));
			sb.AppendLine("To get from " + S[0] + " to " + S[1] + " takes " + BFS(new Pos(a2, b2, 0)) + " knight moves.");
		}

		Console.WriteLine(sb.ToString());
	}
}