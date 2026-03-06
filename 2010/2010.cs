#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
int R = 0;
for (int i = 0; i < N; i++)
{
	R += int.Parse(Console.ReadLine());
}

Console.WriteLine(R - (N - 1));