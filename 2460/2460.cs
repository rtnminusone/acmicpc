#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int r = 0, R = int.MinValue;
string[] S = null;
for (int i = 0; i < 10; i++)
{
	S = Console.ReadLine().Split();
	r += int.Parse(S[1]) - int.Parse(S[0]);
	if (R < r) R = r;
}

Console.WriteLine(R);