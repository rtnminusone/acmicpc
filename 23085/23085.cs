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
			int t = N - p.x;

			if (t == N) return p.w;

			for (int i = 0; i <= K; i++)
			{
				int flipH = i;
				int flipT = K - i;

				if (flipH <= p.x && flipT <= t)
				{
					int x = p.x - flipH + flipT;

					if (!V[x])
					{
						V[x] = true;
						Q.Enqueue(new Pos(x, p.w + 1));
					}
				}
			}
		}

		return -1;
	}

	public static int N, K;
	public static bool[] V = new bool[3001];
	public static List<int> L = new List<int>();
	public static Queue<Pos> Q = new Queue<Pos>();

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);

		int start = 0;
		S[0] = Console.ReadLine();
		for (int i = 0; i < N; i++)
		{
			if (S[0][i] == 'H') start++;
		}

		Q.Enqueue(new Pos(start, 0));
		V[start] = true;

		Console.WriteLine(BFS());
	}
}