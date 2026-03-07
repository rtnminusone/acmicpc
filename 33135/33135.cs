#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<char, int> D = new Dictionary<char, int>();

string S = Console.ReadLine();
for (int i = S.Length - 1; i >= 0; i--)
{
	if (D.ContainsKey(S[i]))
	{
		Console.WriteLine(i + 1);
		break;
	}
	D[S[i]] = 1;
}