#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
int R = 0;
string[] S = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	if (i != int.Parse(S[i]) - 1) R++;
}

Console.WriteLine(R);