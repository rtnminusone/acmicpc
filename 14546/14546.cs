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

	public static Pos Create(int key, int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] != key) return null;
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

	public static string BFS(int key)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == X && p.y == Y) return "YES";

			for (int i = 0; i < 4; i++)
			{
				Push(Create(key, p.x + dx[i], p.y + dy[i]));
			}
		}

		return "NO";
	}

	public static int N, M, X, Y;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[1]);
			M = int.Parse(S[0]);
			T = new int[N, M];
			V = new bool[N, M];
			for (int i = N - 1; i >= 0; i--)
			{
				string s = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					if (s[j] == '+') T[i, j] = 1;
					else T[i, j] = 0;
				}
			}
			int n = int.Parse(S[3]) - 1;
			int m = int.Parse(S[2]) - 1;
			X = int.Parse(S[5]) - 1;
			Y = int.Parse(S[4]) - 1;
			Q.Enqueue(new Pos(n, m));
			V[n, m] = true;

			sb.AppendLine(BFS(T[n, m]));
		}

		Console.WriteLine(sb.ToString());
	}
}