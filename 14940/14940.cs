#pragma warning disable CS8600, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public class Pos
	{
		public int x { get; set; }
		public int y { get; set; }

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N;
	public static int M;
	public static int[, ] T;
	public static int[, ] R;
	public static bool[, ] B;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] == 0) return null;
		return new Pos(x, y);
	}

	public static int Check(Pos pos)
	{
		if (pos == null) return -1;
		if (T[pos.x, pos.y] == 0) return -1;
		return R[pos.x, pos.y];
	}

	public static void Input(Pos pos)
	{
		if (pos == null) return;
		Q.Enqueue(pos);
		B[pos.x, pos.y] = true;
	}

	public static void BFS(Pos pos)
	{
		int Min = -1;
		int Ret = -1;

		Ret = Check(Create(pos.x - 1, pos.y));
		if (Ret != -1 && Ret > Min) Min = Ret;
		Ret = Check(Create(pos.x + 1, pos.y));
		if (Ret != -1 && Ret > Min) Min = Ret;
		Ret = Check(Create(pos.x, pos.y - 1));
		if (Ret != -1 && Ret > Min) Min = Ret;
		Ret = Check(Create(pos.x, pos.y + 1));
		if (Ret != -1 && Ret > Min) Min = Ret;

		if (Min != -1 && Min != int.MaxValue) R[pos.x, pos.y] = Min + 1;
		if (T[pos.x, pos.y] == 0 || T[pos.x, pos.y] == 2) R[pos.x, pos.y] = 0;

		if (Create(pos.x - 1, pos.y) != null && !B[pos.x - 1, pos.y]) Input(new Pos(pos.x - 1, pos.y));
		if (Create(pos.x + 1, pos.y) != null && !B[pos.x + 1, pos.y]) Input(new Pos(pos.x + 1, pos.y));
		if (Create(pos.x, pos.y - 1) != null && !B[pos.x, pos.y - 1]) Input(new Pos(pos.x, pos.y - 1));
		if (Create(pos.x, pos.y + 1) != null && !B[pos.x, pos.y + 1]) Input(new Pos(pos.x, pos.y + 1));
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		T = new int[N, M];
		R = new int[N, M];
		B = new bool[N, M];

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				R[i, j] = 0;
				if (T[i, j] == 2) Input(new Pos(i, j));
			}
		}

		while (Q.Count != 0)
		{
			BFS(Q.Dequeue());
		}

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] == 1 && !B[i, j]) sb.Append("-1 ");
				else sb.Append(R[i, j] + " ");
			}
			sb.AppendLine();
		}

		Console.WriteLine(sb);
	}
}