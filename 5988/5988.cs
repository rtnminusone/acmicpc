#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string S = Console.ReadLine();
	if ((S[S.Length - 1] - '0') % 2 == 0) Console.WriteLine("even");
	else Console.WriteLine("odd");
}