#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N;
	public static int[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();
	public static Dictionary<string, int> D;

	public static bool BFS()
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			foreach (int l in L[q])
			{
				if (V[l] == 0)
				{
					V[l] = 3 - V[q];
					Q.Enqueue(l);
				}
				else
				{
					if (V[q] == V[l]) return false;
				}
			}
		}

		return true;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int n = int.Parse(Console.ReadLine());
		for (int no = 1; no <= n; no++)
		{
			D = new Dictionary<string, int>();
			int m = int.Parse(Console.ReadLine());
			string[] input = new string[m];
			int idx = 0;
			for (int i = 0; i < m; i++)
			{
				input[i] = Console.ReadLine();
				string[] S = input[i].Split();
				if (!D.ContainsKey(S[0])) D[S[0]] = idx++;
				if (!D.ContainsKey(S[1])) D[S[1]] = idx++;
			}
			N = idx;
			V = new int[N];
			L = new List<int>[N];
			for (int i = 0; i < N; i++)
			{
				L[i] = new List<int>();
			}
			for (int i = 0; i < m; i++)
			{
				string[] S = input[i].Split();
				L[D[S[0]]].Add(D[S[1]]);
				L[D[S[1]]].Add(D[S[0]]);
			}
			bool flg = false;
			for (int i = 0; i < N; i++)
			{
				Q.Clear();
				if (V[i] == 0)
				{
					Q.Enqueue(i);
					V[i] = 1;
					if (!BFS())
					{
						flg = true;
						break;
					}
				}
			}
			if (flg) sb.AppendLine("Case #" + no + ": No");
			else sb.AppendLine("Case #" + no + ": Yes");
		}

		Console.WriteLine(sb.ToString());
	}
}