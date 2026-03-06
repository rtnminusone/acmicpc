#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

string[] S = Console.ReadLine().Split();
long R = 0;
for (int i = 0; i < S.Length; i++)
{
	R += long.Parse(S[i]);
}

Console.WriteLine(R);