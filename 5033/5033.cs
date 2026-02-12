#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static bool BFS()
	{
		int sum = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			sum += T[q];

			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return sum == 0;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(Console.ReadLine());
			L[i] = new List<int>();
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0])].Add(int.Parse(S[1]));
			L[int.Parse(S[1])].Add(int.Parse(S[0]));
		}
		bool R = false;
		for (int i = 0; i < N; i++)
		{
			if (!V[i])
			{
				Q.Enqueue(i);
				V[i] = true;
				R = BFS();
				if (!R) break;
			}
		}
		if (!R) Console.WriteLine("IMPOSSIBLE");
		else Console.WriteLine("POSSIBLE");
	}
}