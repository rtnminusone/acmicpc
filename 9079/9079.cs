#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public class Pos
	{
		public string x;
		public int w;

		public Pos(string x, int w)
		{
			this.x = x;
			this.w = w;
		}
	}

	public static string T;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static Dictionary<string, int> V = new Dictionary<string, int>();

	public static int[] dx = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 3, 6, 1, 4, 7, 2, 5, 8, 0, 4, 8, 2, 4, 6 };

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x.Equals("000000000")) return p.w;
			if (p.x.Equals("111111111")) return p.w;

			for (int i = 0; i < 8; i++)
			{
				char[] c = p.x.ToCharArray();
				for (int j = i * 3; j < i * 3 + 3; j++)
				{
					c[dx[j]] = c[dx[j]] == '1' ? '0' : '1';
				}
				string s = new string(c);
				if (V.ContainsKey(s)) continue;
				V[s] = 1;
				Q.Enqueue(new Pos(s, p.w + 1));
			}
		}

		return -1;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		StringBuilder sb2 = new StringBuilder();

		int n = int.Parse(Console.ReadLine());
		while (n-- > 0)
		{
			sb2.Clear();
			for (int i = 0; i < 3; i++)
			{
				string[] S = Console.ReadLine().Split();
				for (int j = 0; j < 3; j++)
				{
					if (S[j].Equals("H")) sb2.Append("1");
					else sb2.Append("0");
				}
			}
			T = sb2.ToString();
			Q.Clear();
			V.Clear();
			V[T] = 1;
			Q.Enqueue(new Pos(T, 0));
			sb.AppendLine(BFS().ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}