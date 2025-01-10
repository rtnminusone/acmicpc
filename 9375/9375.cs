#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public static void AddDict(Dictionary<string, int> D, string key)
	{
		if (D.ContainsKey(key)) D[key]++;
		else D[key] = 1;
	}

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			Dictionary<string, int> D = new Dictionary<string, int>();

			int M = int.Parse(Console.ReadLine());

			for (int j = 0; j < M; j++)
			{
				AddDict(D, Console.ReadLine().Split()[1]);
			}

			int R = 1;

			foreach (int r in D.Values)
			{
				R *= r + 1;
			}

			sb.AppendLine(R - 1 + "");
		}

		Console.WriteLine(sb);
	}
}