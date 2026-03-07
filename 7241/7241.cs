#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N = 3, R = 0;
	public static string K2;
	public static int[] T = new int[N];
	public static int[] K = new int[N];
	public static bool[] V = new bool[N];

	public static void DFS(int depth)
	{
		if (depth == N)
		{
			R++;
			if (string.Join("", K).Equals(K2)) Console.WriteLine(R);
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			V[i] = true;
			K[depth] = T[i];
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		Array.Sort(T);
		K2 = Console.ReadLine();

		DFS(0);
	}
}