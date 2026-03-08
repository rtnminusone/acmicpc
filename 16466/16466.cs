#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<long, int> D = new Dictionary<long, int>();

int N = int.Parse(Console.ReadLine());
string[] S = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	D[int.Parse(S[i])] = 1;
}
for (long i = 1; i < (1L << 31); i++)
{
	if (!D.ContainsKey(i))
	{
		Console.WriteLine(i);
		break;
	}
}