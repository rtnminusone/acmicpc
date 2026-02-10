#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M, W;
	public static int A, B;
	public static bool[] V;
	public static Queue<int> Q;
	public static List<int>[] L;
	public static Dictionary<string, int> D = new Dictionary<string, int>();

	public static bool BFS()
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			if (q == B) return true;

			foreach (int l in L[q])
			{
				if (V[l] || D[q + " " + l] < W) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return false;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		L = new List<int>[N];
		int minW = int.MaxValue;
		int maxW = int.MinValue;
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int a = int.Parse(S[0]) - 1;
			int b = int.Parse(S[1]) - 1;
			int c = int.Parse(S[2]);
			D[a + " " + b] = c;
			D[b + " " + a] = c;
			if (c < minW) minW = c;
			if (c > maxW) maxW = c;
			if (L[a] == null) L[a] = new List<int>();
			L[a].Add(b);
			if (L[b] == null) L[b] = new List<int>();
			L[b].Add(a);
		}
		S = Console.ReadLine().Split();
		A = int.Parse(S[0]) - 1;
		B = int.Parse(S[1]) - 1;

		int R = -1;
		while (minW <= maxW)
		{
			W = (minW + maxW) / 2;
			V = new bool[N];
			Q = new Queue<int>();
			Q.Enqueue(A);
			V[A] = true;
			if (BFS())
			{
				R = W;
				minW = W + 1;
			}
			else
			{
				maxW = W - 1;
			}
		}

		Console.WriteLine(R);
	}
}