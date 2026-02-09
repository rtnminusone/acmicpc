#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 0) return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static int BFS(int label)
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			K[p.x, p.y] = label;
			R++;

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}

		L.Add(R);
		return R;
	}

	public static int N, M;
	public static int[,] T, K;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static List<int> L = new List<int>();
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		K = new int[N, M];
		V = new bool[N, M];
		Q = new Queue<Pos>();

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
			}
		}

		int label = 1;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 1 && !V[i, j])
				{
					Push(Create(i, j));
					D[BFS(label)] = label++;
				}
			}
		}

		StringBuilder sb = new StringBuilder();
		Dictionary<int, int> D2 = new Dictionary<int, int>();
		L.Sort();
		label = 1;
		foreach (int l in L)
		{
			D2[D[l]] = label++;
		}
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (K[i, j] != 0)
				{
					K[i, j] = D2[K[i, j]];
				}
				sb.Append(K[i, j]);
			}
			sb.AppendLine();
		}

		Console.WriteLine(sb.ToString());
	}
}