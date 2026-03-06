#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

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
		int l = left, r = mid + 1, k = 0;

		while (l <= mid && r <= right)
		{
			if (T[l] > T[r]) tmp[k++] = T[r++];
			else tmp[k++] = T[l++];
		}

		while (l <= mid) tmp[k++] = T[l++];
		while (r <= right) tmp[k++] = T[r++];

		for (int i = 0; i < k; i++)
		{
			T[left++] = tmp[i];
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int [N];
		tmp = new int[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		Mergesort(0, N - 1);

		Console.WriteLine(T[N - 1] - T[0]);
	}
}