#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618, CS0660, CS0661

using System;
using System.Text;

class Program
{
	public class Person
	{
		public int h { get; set; }
		public int w { get; set; }

		public Person(int h, int w)
		{
			this.h = h;
			this.w = w;
		}

		public static bool operator > (Person A, Person B)
		{
			if (A.h > B.h && A.w > B.w) return true;
			return false;
		}

		public static bool operator < (Person A, Person B)
		{
			if (A.h < B.h && A.w < B.w) return true;
			return false;
		}

		public static bool operator == (Person A, Person B)
		{
			if (A.h >= B.h && A.w <= B.w) return true;
			else if (A.h <= B.h && A.w >= B.w) return true;
			else return false;
		}

		public static bool operator != (Person A, Person B)
		{
			return !(A == B);
		}
	}

	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		Person[] P = new Person[N];
		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();

			P[i] = new Person(int.Parse(S[0]), int.Parse(S[1]));
		}

		for (int i = 0; i < N; i++)
		{
			int C = 1;
			for (int j = 0; j < N; j++)
			{
				if (i == j) continue;
				if (P[i] < P[j]) C++;
			}
			sb.Append(C + " ");
		}

		Console.WriteLine(sb);
	}
}