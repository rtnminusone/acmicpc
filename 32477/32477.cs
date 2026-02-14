#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return R;
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			if (L[left] == null) L[left] = new List<int>();
			if (L[right] == null) L[right] = new List<int>();
			L[left].Add(right);
			L[right].Add(left);
		}
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			Q.Enqueue(i);
			V[i] = true;
			int r = BFS();
			if (R < r) R = r;
		}

		Console.WriteLine(R);
	}
}