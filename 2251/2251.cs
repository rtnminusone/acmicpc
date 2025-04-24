#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;
using System.Text;

class Program
{
	public class Water
	{
		public int a;
		public int b;
		public int c;

		public Water(int a, int b, int c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
		}
	}

	public static int A;
	public static int B;
	public static int C;
	public static bool[,,] V;
	public static Queue<Water> Q = new Queue<Water>();
	public static Dictionary<int, int> D = new Dictionary<int, int>();
	//public static SortedDictionary<int, int> D = new SortedDictionary<int, int>();

	public static Water Create(int a, int b, int c)
	{
		if (a < 0 || a > A || b < 0 || b > B || c < 0 || c > C) return null;
		if (V[a, b, c]) return null;

		return new Water(a, b, c);
	}

	public static bool Push(Water water)
	{
		if (water == null) return false;

		V[water.a, water.b, water.c] = true;
		Q.Enqueue(water);

		return true;
	}

	public static void BFS()
	{
		while (Q.Count != 0)
		{
			Water w = Q.Dequeue();

			if (w.a == 0 && !D.ContainsKey(w.c)) D[w.c] = 1;

			//ab
			Push(Create(0, w.b + w.a, w.c));
			Push(Create(w.a - (B - w.b), B, w.c));
			//ba
			Push(Create(w.a + w.b, 0, w.c));
			Push(Create(A, w.b - (A - w.a), w.c));
			//ac
			Push(Create(0, w.b, w.c + w.a));
			Push(Create(w.a - (C - w.c), w.b, C));
			//ca
			Push(Create(w.a + w.c, w.b, 0));
			Push(Create(A, w.b, w.c - (A - w.a)));
			//bc
			Push(Create(w.a, 0, w.c + w.b));
			Push(Create(w.a, w.b - (C - w.c), C));
			//cb
			Push(Create(w.a, w.b + w.c, 0));
			Push(Create(w.a, B, w.c - (B - w.b)));
		}
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		A = int.Parse(S[0]);
		B = int.Parse(S[1]);
		C = int.Parse(S[2]);
		V = new bool[A + 1, B + 1, C + 1];
		StringBuilder sb = new StringBuilder();

		V[0, 0, C] = true;
		Q.Enqueue(new Water(0, 0, C));
		BFS();
		var Ans = D.OrderBy(d => d.Key);
		foreach (var d in Ans)
		{
			sb.Append(d.Key + " ");
		}

		Console.WriteLine(sb);
	}
}