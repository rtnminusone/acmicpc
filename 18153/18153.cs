#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1) return p.w - 1;

			foreach(int l in L[p.x])
			{
				if (V[l]) continue;
				V[l] = true;
				Q.Enqueue(new Pos(l, p.w + 1));
			}
		}

		return -1;
	}

	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			L[i] = new List<int>();
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]) - 1);
			L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]) - 1);
		}
		V[0] = true;
		Q.Enqueue(new Pos(0, 0));

		Console.WriteLine(BFS());
	}
}