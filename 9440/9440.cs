#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();

while (true)
{
	string[] S = Console.ReadLine().Split();
	int N = int.Parse(S[0]);
	if (N == 0) break;

	bool[] V = new bool[N];

	List<int> T = new List<int>();
	for (int i = 1; i <= N; i++)
	{
		T.Add(int.Parse(S[i]));
	}

	T.Sort();

	int left = 0, right = 0;
	bool B = true;

	for (int i = 0; i < T.Count; i++)
	{
		if (T[i] != 0)
		{
			left += T[i];
			right += T[i + 1];
			V[i] = true;
			V[i + 1] = true;
			break;
		}
	}

	for (int i = 0; i < T.Count; i++)
	{
		if (V[i]) continue;
		if (B)
		{
			left = left * 10 + T[i];
		}
		else
		{
			right = right * 10 + T[i];
		}
		B = !B;
		V[i] = true;
	}

	sb.AppendLine((left + right) + "");
}

Console.WriteLine(sb);

/* solve by DFS
class Program
{
	public static int N;
	public static int[] T;
	public static int[] P;
	public static bool[] V;
	public static List<int> L;

	public static void DFS(int depth, int mid, int left, int right)
	{
		if (depth == N)
		{
			L.Add(left + right);
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (!V[i] && !((depth == mid - 1 && T[i] == 0) || (depth == N - 1 && T[i] == 0)))
			{
				V[i] = true;
				if (depth < mid) DFS(depth + 1, mid, left + (T[i] * P[depth]), right);
				else DFS(depth + 1, mid, left, right + (T[i] * P[depth - mid]));
				V[i] = false;
			}
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			T = new int[N];
			V = new bool[N];
			P = new int[N / 2 + 1];
			L = new List<int>();

			if (N == 0) break;

			for (int i = 1; i <= N; i++)
			{
				T[i - 1] = int.Parse(S[i]);
			}

			for (int i = 0; i <= N / 2; i++)
			{
				P[i] = (int)Math.Pow(10, i);
			}

			DFS(0, N / 2, 0, 0);

			L.Sort();

			sb.AppendLine(L[0] + "");
		}

		Console.WriteLine(sb);
	}
}
*/