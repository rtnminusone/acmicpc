#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public static int N, K, M;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static List<int> D = new List<int>();
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			T[q] = w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		M = int.Parse(S[2]);
		T = new int[N];
		V = new bool[N];
		Array.Fill(T, int.MaxValue);
		L = new List<int>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			D.Add(int.Parse(S[i]));
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			if (L[left] == null) L[left] = new List<int>();
			if (L[right] == null) L[right] = new List<int>();
			L[left].Add(right);
			L[right].Add(left);
		}
		foreach (int d in D)
		{
			Q.Enqueue((d, 0));
			V[d] = true;
		}
		BFS();
		int R = 0;
		int MV = int.MinValue;
		for (int i = 0; i < N; i++)
		{
			if (T[i] > MV)
			{
				R = i;
				MV = T[i];
			}
		}

		Console.WriteLine(R);
	}
}