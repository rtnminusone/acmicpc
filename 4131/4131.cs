#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public static long N, M, K;
	public static bool[] V;
	public static List<(long, long)> L = new List<(long, long)>();
	public static Queue<(long, long)> Q = new Queue<(long, long)>();

	public static long BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q == 0) return w;

			foreach (var (lx, ly) in L)
			{
				long next = (q * lx + ly) % M;
				if (V[next]) continue;
				Q.Enqueue((next, w + 1));
				V[next] = true;
			}
		}

		return -1;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		M = long.Parse(S[0]);
		N = long.Parse(S[1]);
		K = long.Parse(S[2]);
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			L.Add((long.Parse(S[0]), long.Parse(S[1])));
		}
		V = new bool[M];

		V[K] = true;
		Q.Enqueue((K, 0));

		Console.WriteLine(BFS());
	}
}