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

	public static Pos Create(int x, int w)
	{
		if (V[x]) return null;

		return new Pos(x, w);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x] = true;

		return true;
	}

	public static bool[] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int Reverse(int num)
	{
		bool flg = false;
		string s = num.ToString();
		StringBuilder sb = new StringBuilder();
		for (int i = s.Length - 1; i >= 0; i--)
		{
			if (!flg)
			{
				if (s[i] == '0') continue;
				flg = true;
			}
			sb.Append(s[i]);
		}

		return int.Parse(sb.ToString());
	}

	public static int BFS(int goal)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal) return p.w;

			Push(Create(p.x + 1, p.w + 1));
			Push(Create(Reverse(p.x), p.w + 1));
		}

		return -1;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int n = int.Parse(Console.ReadLine());
		for (int a = 1; a <= n; a++)
		{
			V = new bool[10000000];
			Q.Clear();
			Push(Create(1, 1));
			sb.AppendLine("Case #" + a + ": " + BFS(int.Parse(Console.ReadLine())));
		}

		Console.WriteLine(sb.ToString());
	}
}