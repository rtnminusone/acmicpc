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

			if (K[p.x, p.y] != 0) continue;

			for (int i = 0 ; i < 8; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}
	}

	public static void CalK()
	{
		for (int x = 0; x < N; x++)
		{
			for (int y = 0; y < N; y++)
			{
				if (T[x, y] == 1)
				{
					K[x, y] = -1;
					continue;
				}
				int r = 0;
				for (int z = 0; z < 8; z++)
				{
					int X = x + dx[z];
					int Y = y + dy[z];
					if (X < 0 || X >= N || Y < 0 || Y >= N) continue;
					if (T[X, Y] == 1) r++;
				}
				K[x, y] = r;
			}
		}
	}

	public static int N;
	public static int[,] T, K;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		for (int a = 1; a <= t; a++)
		{
			N = int.Parse(Console.ReadLine());
			T = new int[N, N];
			K = new int[N, N];
			V = new bool[N, N];
			Q = new Queue<Pos>();
			for (int i = 0; i < N; i++)
			{
				string S = Console.ReadLine();
				for (int j = 0; j < N; j++)
				{
					if (S[j] == '.') T[i, j] = 0;
					else T[i, j] = 1;
				}
			}
			CalK();
			int R = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (K[i, j] == 0 && !V[i, j])
					{
						Push(Create(i, j));
						BFS();
						R++;
					}
				}
			}
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (K[i, j] != -1 && !V[i, j]) R++;
				}
			}
			sb.AppendLine("Case #" + a + ": " + R);
		}

		Console.WriteLine(sb.ToString());
	}
}