#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

string[] S = null;
int N = int.Parse(Console.ReadLine());
int[] T = new int[3] { 1, 0, 0 };
for (int i = 0; i < N; i++)
{
	S = Console.ReadLine().Split();
	int a = int.Parse(S[0]) - 1;
	int b = int.Parse(S[1]) - 1;
	int tmp = T[a];
	T[a] = T[b];
	T[b] = tmp;
}
for (int i = 0; i < 3; i++)
{
	if (T[i] == 1) Console.WriteLine(i + 1);
}