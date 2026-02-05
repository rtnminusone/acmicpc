#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int[] T = new int[9];

	public static void DFS(int depth, int idx, int sum, int[] t)
	{
		if (idx > 7) return;
		if (depth == 9)
		{
			if (idx == 7 && sum == 100)
			{
				Array.Sort(t);
				Console.WriteLine(string.Join("\n", t));
				Environment.Exit(0);
			}
			return;
		}

		if (idx < 7)
		{
			t[idx] = T[depth];
			DFS(depth + 1, idx + 1, sum + t[idx], t);
		}
		DFS(depth + 1, idx, sum, t);
	}

	public static void Main(string[] args)
	{
		for (int i = 0; i < 9; i++)
		{
			T[i] = int.Parse(Console.ReadLine());
		}

		DFS(0, 0, 0, new int[7]);
	}
}