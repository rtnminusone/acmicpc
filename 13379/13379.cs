#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System.Text;

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<(int, int)>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static int BFS()
	{
		int R = int.MinValue;

		while (Q.Count > 0)
		{
			var (q1, q2) = Q.Dequeue();

			if (R < q2) R = q2;

			if (L[q1] == null) continue;
			foreach (var (l1, l2) in L[q1])
			{
				if (V[l1]) continue;
				Q.Enqueue((l1, q2 + l2));
				V[l1] = true;
			}
		}

		return R;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			L = new List<(int, int)>[N];
			for (int i = 0; i < N - 1; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[0]) - 1;
				if (L[left] == null) L[left] = new List<(int, int)>();
				L[left].Add((int.Parse(S[1]) - 1, int.Parse(S[2])));
			}
			V = new bool[N];
			V[0] = true;
			Q.Enqueue((0, 0));
			int r = BFS();
			if (r >= M) sb.AppendLine(r.ToString());
			else sb.AppendLine("-1");
		}

		Console.WriteLine(sb.ToString());
	}
}