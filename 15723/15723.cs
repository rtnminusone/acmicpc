#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N, M;
	public static int[,] T = new int[26, 26];
	public static bool[] V;
	public static Queue<int> Q;

	public static void BFS(int start)
	{
		while (Q.Count != 0)
		{
			int q = Q.Dequeue();

			for (int i = 0; i < 26; i++)
			{
				if (T[q, i] == 0 || V[i]) continue;

				Q.Enqueue(i);
				T[start, i] = 1;
				V[i] = true;
			}
		}
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			T[S[0][0] - 'a', S[2][0] - 'a'] = 1;
		}

		for (int i = 0; i < 26; i++)
		{
			Q = new Queue<int>();
			V = new bool[26];
			V[i] = true;
			Q.Enqueue(i);
			BFS(i);
		}

		M = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < M; i++)
		{
			string[] S = Console.ReadLine().Split();
			if (T[S[0][0] - 'a', S[2][0] - 'a'] == 1) sb.AppendLine("T");
			else sb.AppendLine("F");
		}

		Console.WriteLine(sb.ToString());
	}
}