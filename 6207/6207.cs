#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M, K;
	public static int[] COW;
	public static int[] R;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R[q]++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		K = int.Parse(S[0]);
		N = int.Parse(S[1]);
		M = int.Parse(S[2]);
		COW = new int[K];
		R = new int[N];
		L = new List<int>[N];
		for (int i = 0; i < K; i++)
		{
			COW[i] = int.Parse(Console.ReadLine()) - 1;
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			if (L[left] == null) L[left] = new List<int>();
			L[left].Add(int.Parse(S[1]) - 1);
		}
		for (int i = 0; i < K; i++)
		{
			Q.Enqueue(COW[i]);
			V = new bool[N];
			V[COW[i]] = true;
			BFS();
		}
		int res = 0;
		foreach (int r in R)
		{
			if (r == K) res++;
		}

		Console.WriteLine(res);
	} 
}