#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public struct Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N, M;
	public static char[,] T;
	public static int[,,] dist;
	public static PriorityQueue<(Pos, int, int), int> PQ = new PriorityQueue<(Pos, int, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == '#') return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w, v) = PQ.Dequeue();

			if (w > dist[p.x, p.y, v]) continue;

			if (T[p.x, p.y] == '1') return w;

			for (int i = 0; i < 4; i++)
			{
				int nextx = p.x + dx[i];
				int nexty = p.y + dy[i];
				if (Create(nextx, nexty, out Pos pos))
				{
					char t = T[pos.x, pos.y];
					if ('A' <= t && t <= 'F')
					{
						int idx = t - 'A';
						if ((v & (1 << idx)) == 0) continue;
						if (dist[pos.x, pos.y, v] > w + 1)
						{
							PQ.Enqueue((pos, w + 1, v), w + 1);
							dist[pos.x, pos.y, v] = w + 1;
						}
					}
					else if ('a' <= t && t <= 'f')
					{
						int idx = t - 'a';
						int nextv = (v | (1 << idx));
						if (dist[pos.x, pos.y, nextv] > w + 1)
						{
							PQ.Enqueue((pos, w + 1, nextv), w + 1);
							dist[pos.x, pos.y, nextv] = w + 1;
						}
					}
					else
					{
						if (dist[pos.x, pos.y, v] > w + 1)
						{
							PQ.Enqueue((pos, w + 1, v), w + 1);
							dist[pos.x, pos.y, v] = w + 1;
						}
					}
				}
			}
		}

		return -1;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new char[N, M];
		dist = new int[N, M, (1 << 6)];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				for (int k = 0; k < (1 << 6); k++)
				{
					dist[i, j, k] = int.MaxValue;
				}
				T[i, j] = S[0][j];
				if (T[i, j] == '0')
				{
					PQ.Enqueue((new Pos(i, j), 0, 0), 0);
					dist[i, j, 0] = 0;
				}
			}
		}

		Console.WriteLine(Dijkstra());
	}
}