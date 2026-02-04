#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		long A = long.Parse(S[0]);
		long B = long.Parse(S[1]);
		long C = long.Parse(S[2]);

		if (B >= C)
		{
			Console.WriteLine(-1);
			return;
		}

		Console.WriteLine((A / (C - B) + 1));
	}
}