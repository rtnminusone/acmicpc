#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N;
	public static int[] T, tmp;

	public static void Mergesort(int left, int right)
	{
		if (left >= right) return;

		int mid = (left + right) / 2;

		Mergesort(left, mid);
		Mergesort(mid + 1, right);

		Merge(left, mid, right);
	}

	public static void Merge(int left, int mid, int right)
	{
		int k = 0, l = left, r = mid + 1;

		while (l <= mid && r <= right)
		{
			if (T[l] > T[r]) tmp[k++] = T[l++];
			else tmp[k++] = T[r++];
		}

		while (l <= mid) tmp[k++] = T[l++];
		while (r <= right) tmp[k++] = T[r++];

		k = 0;
		for (int i = left; i <= right; i++)
		{
			T[i] = tmp[k++];
		}
	}

	public static void Main()
	{
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		StringBuilder sb = new StringBuilder();

		N = int.Parse(sr.ReadLine());
		T = new int[N];
		tmp = new int[N];
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(sr.ReadLine());
		}

		Mergesort(0, N - 1);

		for (int i = 0; i < N; i++)
		{
			sb.AppendLine(T[i].ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}