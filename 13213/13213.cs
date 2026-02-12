#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public class Node
	{
		public int x;
		public int w;

		public Node(int x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public class Pos
	{
		public int x;
		public int y;
		public int w;

		public Pos(int x, int y, int w)
		{
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1) return p.w;

			if (L[p.x] == null) continue;
			foreach (Node n in L[p.x])
			{
				if (p.y == n.w || V[n.x, n.w]) continue;
				Q.Enqueue(new Pos(n.x, n.w, p.w + 1));
				V[n.x, n.w] = true;
			}
		}

		return -1;
	}

	public static int N, M;
	public static List<Node>[] L;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		L = new List<Node>[N];
		V = new bool[N, 2];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			if (L[left] == null) L[left] = new List<Node>();
			if (L[right] == null) L[right] = new List<Node>();
			L[left].Add(new Node(right, int.Parse(S[2])));
			L[right].Add(new Node(left, int.Parse(S[2])));
		}
		Q.Enqueue(new Pos(0, 0, 0));
		Q.Enqueue(new Pos(0, 1, 0));
		V[0, 0] = true;
		V[0, 1] = true;

		Console.WriteLine(BFS());
	}
}