#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
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
		if (T[x, y] == '*') return null;
		if ('A' <= T[x, y] && T[x, y] <= 'Z') return null;
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

	public static int BFS()
	{
		int R = 0;

		while (Q.Count != 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == '$') R++;
			if ('a' <= T[p.x, p.y] && T[p.x, p.y] <= 'z' && !Key.Contains(T[p.x, p.y]))
			{
				Open(T[p.x, p.y]);
				Key.Add(T[p.x, p.y]);
				V = new bool[N, M];
				R = 0;
				Init();
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					Push(Create(p.x + dx[i], p.y + dy[i]));
				}
			}
		}

		return R;
	}

	public static void Open(char c)
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == char.ToUpper(c)) T[i, j] = '.';
			}
		}
	}

	public static void Init()
	{
		Q = new Queue<Pos>();
		for (int i = 0; i < M; i++)
		{
			Push(Create(0, i));
			Push(Create(N - 1, i));
		}
		for (int i = 0; i < N; i++)
		{
			Push(Create(i, 0));
			Push(Create(i, M - 1));
		}
	}

	public static int N, M;
	public static char[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;
	public static List<char> Key;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int n = int.Parse(Console.ReadLine());

		while (n-- != 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			T = new char[N, M];
			V = new bool[N, M];
			Key = new List<char>();

			for (int i = 0; i < N; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					T[i, j] = S[0][j];
				}
			}
			S[0] = Console.ReadLine();
			if (S[0] != "0")
			{
				for (int i = 0; i < S[0].Length; i++)
				{
					Open(S[0][i]);
					Key.Add(S[0][i]);
				}
			}

			Init();
			sb.AppendLine(BFS() + "");
		}

		Console.WriteLine(sb);
	}
}