#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		N = N * (N + 1) / 2;

		Console.WriteLine(N + "\n" + (N * N) + "\n" + (N * N));
	}
}