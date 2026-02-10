#pragma warning disable CS8602

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]) * int.Parse(S[1]);
S = Console.ReadLine().Split();
for (int i = 0; i < 5; i++)
{
	Console.Write(int.Parse(S[i]) - N + " ");
}