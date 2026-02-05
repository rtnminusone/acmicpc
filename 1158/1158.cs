#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N, K;
	public static List<int> L = new List<int>();

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		int r = 0;
		int[] R = new int[N];

		for (int i = 1; i <= N; i++)
		{
			L.Add(i);
		}

		int idx = 0;
		while (L.Count > 0)
		{
			idx = (idx + K - 1 + L.Count) % L.Count;
			R[r++] = L[idx];
			L.RemoveAt(idx);
		}

		sb.Append("<");
		sb.Append(string.Join(", ", R));
		Console.WriteLine(sb.ToString() + ">");
	}
}