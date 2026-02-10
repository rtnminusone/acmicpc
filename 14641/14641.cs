#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N, M;
	public static int MAX = 'z' - 'a' + 1;
	public static bool[] V;
	public static List<int> B = new List<int>();
	public static Queue<int> Q;
	public static List<int>[] L = new List<int>[MAX];
	public static Dictionary<string, int> D = new Dictionary<string, int>();

	public static void BFS(int start)
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			D[(char)(start + 'a') + " " + (char)(q + 'a')] = 1;

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
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		for (int i = 0; i < MAX; i++)
		{
			L[i] = new List<int>();
		}
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			L[S[0][0] - 'a'].Add(S[1][0] - 'a');
			B.Add(S[0][0] - 'a');
		}
		foreach (int b in B)
		{
			V = new bool[MAX];
			Q = new Queue<int>();
			Q.Enqueue(b);
			V[b] = true;
			BFS(b);
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			if (S[0].Length != S[1].Length)
			{
				sb.AppendLine("no");
				continue;
			}
			int j = 0;
			for (j = 0; j < S[0].Length; j++)
			{
				if (S[0][j] == S[1][j]) continue;
				if (!D.ContainsKey(S[0][j] + " " + S[1][j])) break;
			}
			if (j != S[0].Length) sb.AppendLine("no");
			else sb.AppendLine("yes");
		}

		Console.WriteLine(sb.ToString());
	}
}