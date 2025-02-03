#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static int N;
	public static int[] T;
	public static int[] R;
	public static bool[] V;
	public static StringBuilder sb = new StringBuilder();

	public static void back_tracking(int depth)
	{
		if (depth == N)
		{
			sb.AppendLine(String.Join(" ", R));
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (!V[i] && Cal(depth, i))
			{
				V[i] = true;
				R[depth] = i + 1;
				back_tracking(depth + 1);
				V[i] = false;
			}
		}
	}

	public static bool Cal(int depth, int P)
	{
		int H = 0;

		for (int i = 0; i < depth; i++)
		{
			if (R[i] > P + 1) H++;
		}

		if (H != T[P]) return false;
		return true;
	}

	public static void Main(string[] args)
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		R = new int[N];
		V = new bool[N];

		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		back_tracking(0);

		Console.WriteLine(sb);
	}
}