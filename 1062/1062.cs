#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, K, R = 0;
	public static string[] T;
	public static bool[] B = new bool['z' - 'a' + 1];
	public static List<char> L = new List<char>();
	public static Dictionary<char, int> D = new Dictionary<char, int>();

	public static int Check()
	{
		int r = 0;

		foreach (string t in T)
		{
			bool ans = true;
			for (int i = 4; i < t.Length - 4; i++)
			{
				if (!B[t[i] - 'a'])
				{
					ans = false;
					break;
				}
			}
			if (ans) r++;
		}

		return r;
	}

	public static void DFS(int depth, int start)
	{
		if (depth == K)
		{
			int r = Check();
			if (r > R) R = r;
			return;
		}

		for (int i = start; i < L.Count; i++)
		{
			B[L[i] - 'a'] = true;
			DFS(depth + 1, i + 1);
			B[L[i] - 'a'] = false;
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new string[N];
		if (K < 5) Console.WriteLine(0);
		else
		{
			B['a' - 'a'] = true;
			B['n' - 'a'] = true;
			B['t' - 'a'] = true;
			B['i' - 'a'] = true;
			B['c' - 'a'] = true;
			K -= 5;
			for (int i = 0; i < N; i++)
			{
				T[i] = Console.ReadLine();
				foreach (char s in T[i])
				{
					if (s == 'a' || s == 'n' || s == 't' || s == 'i' || s == 'c') continue;
					D[s] = 1;
				}
			}
			foreach (char d in D.Keys)
			{
				L.Add(d);
			}
			if (L.Count < K)
			{
				Console.WriteLine(N);
				return;
			}

			DFS(0, 0);

			Console.WriteLine(R);
		}
	}
}