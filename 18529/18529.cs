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

	public static int N, K;
	public static int[,] T, dist, DP;
	public static Dictionary<int, bool> D = new Dictionary<int, bool>();
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= N) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y]) continue;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (dist[pos.x, pos.y] > w + 1)
					{
						PQ.Enqueue((pos, w + 1), w + 1);
						dist[pos.x, pos.y] = w + 1;
					}
				}
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[N, N];
		dist = new int[N, N];
		DP = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] <= K && !D.ContainsKey(T[i, j])) D[T[i, j]] = true;
			}
		}

		if (D.Count != K)
		{
			Console.WriteLine(-1);
			Environment.Exit(0);
		}

		for (int k = 1; k < K; k++)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					dist[i, j] = int.MaxValue;
					if (T[i, j] == k)
					{
						dist[i, j] = DP[i, j];
						PQ.Enqueue((new Pos(i, j), dist[i, j]), dist[i, j]);
					}
				}
			}

			Dijkstra();

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (T[i, j] == k + 1) DP[i, j] = dist[i, j];
				}
			}
		}

		int R = int.MaxValue;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				if (T[i, j] == K)
				{
					if (R > DP[i, j]) R = DP[i, j];
				}
			}
		}

		Console.WriteLine(R);
	}
}