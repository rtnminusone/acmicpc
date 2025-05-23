﻿#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System;

class Program
{
	public class Pos
	{
		public int id;
		public int x;
		public int y;
		public int w;

		public Pos(int id, int x, int y, int w)
		{
			this.id = id;
			this.x = x;
			this.y = y;
			this.w = w;
		}

		public static Pos Create(int id, int x, int y, int w)
		{
			if (x < 0 || x >= N || y < 0 || y >= N) return null;
			if (V[x, y]) return null;

			return new Pos(id, x, y, w);
		}

		public static bool Push(Pos pos)
		{
			if (pos == null) return false;

			Q.Enqueue(pos);
			V[pos.x, pos.y] = true;

			return true;
		}

		public static void BFS()
		{
			while (Q.Count != 0)
			{
				Pos p = Q.Dequeue();

				if (p.w > K) break;
				if (F[p.x, p.y] == 0) F[p.x, p.y] = p.id;

				for (int i = 0; i < 4; i++)
				{
					Push(Create(p.id, p.x + dx[i], p.y + dy[i], p.w + 1));
				}
			}
		}

		public static int N;
		public static int M;
		public static int K;
		public static int[,] T;
		public static int[,] F;
		public static bool[,] V;
		public static Queue<Pos> Q;

		public static int[] dx = { -1, 0, 1, 0 };
		public static int[] dy = { 0, -1, 0, 1 };

		public static void Main(string[] args)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			T = new int[N, N];
			F = new int[N, N];
			V = new bool[N, N];
			Q = new Queue<Pos>();
			List<Pos>[] L = new List<Pos>[M];

			for (int i = 0; i < M; i++)
			{
				L[i] = new List<Pos>();
			}

			for (int i = 0; i < N; i++)
			{
				S = Console.ReadLine().Split();
				for (int j = 0; j < N; j++)
				{
					T[i, j] = int.Parse(S[j]);
					if (T[i, j] != 0) L[T[i, j] - 1].Add(new Pos(T[i, j], i, j, 0));
				}
			}

			S = Console.ReadLine().Split();
			K = int.Parse(S[0]);
			int x = int.Parse(S[1]) - 1;
			int y = int.Parse(S[2]) - 1;

			for (int i = 0; i < M; i++)
			{
				foreach (var v in L[i])
				{
					Push(v);
				}
			}

			BFS();

			Console.WriteLine(F[x, y]);
		}
	}
}