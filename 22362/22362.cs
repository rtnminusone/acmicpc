#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

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
		if (T[x, y] != 1) return null;
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

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			R++;

			for (int i = -1 * D; i <= D; i++)
			{
				Push(Create(p.x + i, p.y));
				Push(Create(p.x, p.y + i));
			}
		}

		return R;
	}

	public static int N, M, D;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			M = int.Parse(S[0]);
			N = int.Parse(S[1]);
			int n = int.Parse(S[2]);
			D = int.Parse(S[3]);
			int b = int.Parse(S[4]) - 1;
			if (N == 0 && M == 0 && n == 0 && D == 0 && b + 1== 0) break;
			T = new int[N, M];
			V = new bool[N, M];
			Q = new Queue<Pos>();
			for (int i = 0; i < n; i++)
			{
				S = Console.ReadLine().Split();
				T[int.Parse(S[1]) - 1, int.Parse(S[0]) - 1] = 1;
				if (i == b) Push(Create(int.Parse(S[1]) - 1, int.Parse(S[0]) - 1));
			}
			sb.AppendLine(BFS().ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}