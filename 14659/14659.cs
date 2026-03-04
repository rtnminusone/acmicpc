#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		string[] S = Console.ReadLine().Split();
		int R = 0, r = 0, left = int.Parse(S[0]);
		for (int i = 1; i < N; i++)
		{
			if (left <= int.Parse(S[i]))
			{
				if (r > R) R = r;
				left = int.Parse(S[i]);
				r = 0;
			}
			else r++;
		}

		Console.WriteLine(R < r ? r : R);
	}
}