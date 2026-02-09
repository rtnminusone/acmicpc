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
		if (x < 0 || x >= N || y < 0 || y >= N) return null;
		if (T[x, y] == 2) return null;
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

			if (T[p.x, p.y] == 0) R++;

			for (int i = 0; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}

		return R;
	}

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		int n = int.Parse(Console.ReadLine());
		while (n-- > 0)
		{
			N = int.Parse(Console.ReadLine());
			T = new int[N, N];
			V = new bool[N, N];
			for (int i = 0; i < N; i++)
			{
				string S = Console.ReadLine();
				for (int j = 0; j < N; j++)
				{
					if (S[j] == '-') T[i, j] = 0;
					else if (S[j] == 'w') T[i, j] = 1;
					else T[i, j] = 2;
				}
			}

			int R = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (T[i, j] == 1 && !V[i, j])
					{
						Push(Create(i, j));
						R += BFS();
					}
				}
			}

			sb.AppendLine(R.ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}