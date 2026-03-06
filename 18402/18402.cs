#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, E, T, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		E = int.Parse(Console.ReadLine()) - 1;
		T = int.Parse(Console.ReadLine());
		M = int.Parse(Console.ReadLine());
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			string[] S = Console.ReadLine().Split();
			int left = int.Parse(S[1]) - 1;
			int right = int.Parse(S[0]) - 1;
			(L[left] ??= new List<(int, int)>()).Add((right, int.Parse(S[2])));
		}

		PQ.Enqueue((E, 0), 0);
		dist[E] = 0;

		Dijkstra();

		int R = 0;
		for (int i = 0; i < N; i++)
		{
			if (dist[i] <= T) R++;
		}

		Console.WriteLine(R);
	}
}