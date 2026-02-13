#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public class Pos
	{
		public int x;
		public int w;

		public Pos(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static int N, M;
	public static bool[] V;
	public static List<Pos>[] L;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static string BFS(int goal)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal) return p.w.ToString();

			if (L[p.x] == null) continue;

			foreach (Pos l in L[p.x])
			{
				if (V[l.x]) continue;
				Q.Enqueue(new Pos(l.x, p.w + l.w));
				V[l.x] = true;
			}
		}

		return "-1";
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		L = new List<Pos>[N];
		for (int i = 0; i < N - 1; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			if (L[left] == null) L[left] = new List<Pos>();
			if (L[right] == null) L[right] = new List<Pos>();
			L[left].Add(new Pos(right, int.Parse(S[2])));
			L[right].Add(new Pos(left, int.Parse(S[2])));
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			Q.Clear();
			V = new bool[N];
			V[int.Parse(S[0]) - 1] = true;
			Q.Enqueue(new Pos(int.Parse(S[0]) - 1, 0));
			sb.AppendLine(BFS(int.Parse(S[1]) - 1));
		}

		Console.WriteLine(sb.ToString());
	}
}