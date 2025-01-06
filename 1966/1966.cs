#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

class Program
{
	public class Pair
	{
		public int Key { get; set; }
		public int Value { get; set; }

		public Pair(int Key, int Value)
		{
			this.Key = Key;
			this.Value = Value;
		}
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			Queue<Pair> Q = new Queue<Pair>();

			string[] S = Console.ReadLine().Split();
			int M = int.Parse(S[0]);
			int K = int.Parse(S[1]);
			S = Console.ReadLine().Split();

			for (int j = 0; j < M; j++)
			{
				Q.Enqueue(new Pair(j, int.Parse(S[j])));
			}

			int C = 0;

			while (Q.Count != 0)
			{
				Pair T = Q.OrderByDescending(k => k.Value).First();
				if (Q.Peek().Value == T.Value)
				{
					C++;
					if (Q.Peek().Key == K)
					{
						sb.AppendLine(C + "");
						break;
					}
					else Q.Dequeue();
				}
				else Q.Enqueue(Q.Dequeue());
			}
		}

		Console.WriteLine(sb);
	}
}