#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static Queue<string> Q = new Queue<string>();
	public static Dictionary<string, int> D = new Dictionary<string, int>();
	public static Dictionary<string, List<string>> L = new Dictionary<string, List<string>>(); 

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			string s = Q.Dequeue();

			if (D.ContainsKey(s)) D.Remove(s);

			if (L.ContainsKey(s))
			{
				foreach (string key in L[s])
				{
					if (!D.ContainsKey(key)) continue;
					Q.Enqueue(key);
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			D[Console.ReadLine()] = 1;
		}
		N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			if (L.ContainsKey(S[0])) L[S[0]].Add(S[1]);
			else
			{
				L[S[0]] = new List<string>();
				L[S[0]].Add(S[1]);
			}
			if (L.ContainsKey(S[1])) L[S[1]].Add(S[0]);
			else
			{
				L[S[1]] = new List<string>();
				L[S[1]].Add(S[0]);
			}
		}
		int R = 0;
		foreach (string key in D.Keys)
		{
			if (D.ContainsKey(key))
			{
				Q.Enqueue(key);
				BFS();
				R++;
			}
		}

		Console.WriteLine(R);
	}
}