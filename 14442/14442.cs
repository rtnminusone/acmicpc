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

	public static int N, M, K;
	public static int[,] T;
	public static int[,,] dist;
	public static PriorityQueue<(Pos, int, int), int> PQ = new PriorityQueue<(Pos, int, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, k, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y, k]) continue;

			if (p.x == N - 1 && p.y == M - 1) return w;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (T[pos.x, pos.y] == 1)
					{
						if (k >= K) continue;
						if (dist[pos.x, pos.y, k + 1] > w + 1)
						{
							PQ.Enqueue((pos, k + 1, w + 1), w + 1);
							dist[pos.x, pos.y, k + 1] = w + 1;
						}
					}
					else
					{
						if (dist[pos.x, pos.y, k] > w + 1)
						{
							PQ.Enqueue((pos, k, w + 1), w + 1);
							dist[pos.x, pos.y, k] = w + 1;
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
		K = int.Parse(S[2]);
		T = new int[N, M];
		dist = new int[N, M, K + 1];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				for (int k = 0; k <= K; k++)
				{
					dist[i, j, k] = int.MaxValue;
				}
				T[i, j] = S[0][j] - '0';
			}
		}
		PQ.Enqueue((new Pos(0, 0), 0, 1), 1);
		dist[0, 0, 0] = 1;

		Console.WriteLine(Dijkstra());
	}
}