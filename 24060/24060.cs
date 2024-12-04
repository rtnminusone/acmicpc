#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static int count;
	public static int target;

	public static void merge_sort(int[] A, int p, int r)
	{
		if (p < r)
		{
			int q = (p + r) / 2;
			merge_sort(A, p, q);
			merge_sort(A, q + 1, r);
			merge(A, p, q, r);
		}
	}

	public static void merge(int[] A, int p, int q, int r)
	{
		int ll = 0;
		int rr = 0;
		int k = p;

		int[] L = new int[q - p + 1];
		int[] R = new int[r - q];

		Array.Copy(A, p, L, 0, q - p + 1);
		Array.Copy(A, q + 1, R, 0, r - q);

		while (ll < q - p + 1 && rr < r - q)
		{
			if (L[ll] > R[rr])
			{
				count++;
				if (count == target)
				{
					Console.WriteLine(R[rr]);
					Environment.Exit(0);
				}
				A[k++] = R[rr++];
			}
			else
			{
				count++;
				if (count == target)
				{
					Console.WriteLine(L[ll]);
					Environment.Exit(0);
				}
				A[k++] = L[ll++];
			}
		}

		while (ll < q - p + 1)
		{
			count++;
			if (count == target)
			{
				Console.WriteLine(L[ll]);
				Environment.Exit(0);
			}
			A[k++] = L[ll++];
		}
		while (rr < r - q)
		{
			count++;
			if (count == target)
			{
				Console.WriteLine(R[rr]);
				Environment.Exit(0);
			}
			A[k++] = R[rr++];
		}
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split(' ');
		int N = int.Parse(S[0]);
		target = int.Parse(S[1]);
		count = 0;
		int[] A = new int[N];

		S = Console.ReadLine().Split(' ');

		for (int i = 0; i < N; i++)
		{
			A[i] = int.Parse(S[i]);
		}

		merge_sort(A, 0, A.Length - 1);

		Console.WriteLine(-1);
	}
}