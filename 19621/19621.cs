#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

class Program
{
	public class Pos
	{
		public int First { get; set; }
		public int Last { get; set; }
		public int Point { get; set; }

		public Pos(int Last, int Point)
		{
			this.Last = Last;
			this.Point = Point;
		}

		public Pos(int First, int Last, int Point)
		{
			this.First = First;
			this.Last = Last;
			this.Point = Point;
		}
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		List<Pos> L = new List<Pos>();

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			L.Add(new Pos(int.Parse(S[0]), int.Parse(S[1]), int.Parse(S[2])));
		}

		L = L.OrderBy(k => k.Last).ToList();
		Pos[] DP = new Pos[L.Count + 1];

		DP[0] = new Pos(0, 0, 0);
		for (int i = 1; i <= L.Count; i++)
		{
			if (DP[i - 1].Last > L[i - 1].First)
			{
				for (int j = i - 2; j >= 0; j--)
				{
					if (DP[j].Last > L[i - 1].First) continue;
					if (DP[i - 1].Point < DP[j].Point + L[i - 1].Point) DP[i] = new Pos(0, L[i - 1].Last, DP[j].Point + L[i - 1].Point);
					else DP[i] = DP[i - 1];
					break;
				}
			}
			else DP[i] = new Pos(0, L[i - 1].Last, L[i - 1].Point + DP[i - 1].Point);
		}

		Console.WriteLine(DP[L.Count].Point);
	}
}