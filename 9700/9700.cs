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
		if (T[x, y] == 0) return null;
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

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string ReadLine;
		int idx = 1;
		while ((ReadLine = Console.ReadLine()) != null)
		{
			N = int.Parse(ReadLine);
			if (N == 0) break;
			T = new int[N, N];
			V = new bool[N, N];
			for (int i = 0; i < N; i++)
			{
				string S = Console.ReadLine();
				for (int j = 0; j < N; j++)
				{
					T[i, j] = S[j] - '0';
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
						BFS();
						R++;
					}
				}
			}
			sb.AppendLine("Case #" + idx++ + ": " + R);
		}

		Console.WriteLine(sb.ToString());
	}
}