#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int T = int.Parse(Console.ReadLine());
while (T-- > 0)
{
	string[] S = Console.ReadLine().Split();
	int A = int.Parse(S[0]);
	int B = int.Parse(S[1]);

	Console.WriteLine("You get " + (A / B) + " piece(s) and your dad gets " + (A % B) + " piece(s).");
}