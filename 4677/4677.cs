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

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			if (N == 0 && M == 0) break;
			T = new int[N, M];
			V = new bool[N, M];
			Q = new Queue<Pos>();
			for (int i = 0; i < N; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					if (S[0][j] == '*') T[i, j] = 0;
					else T[i, j] = 1;
				}
			}
			int R = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] == 1 && !V[i, j])
					{
						Push(Create(i, j));
						BFS();
						R++;
					}
				}
			}
			sb.AppendLine(R.ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}