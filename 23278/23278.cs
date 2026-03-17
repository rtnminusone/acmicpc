#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int L = int.Parse(S[1]);
int H = int.Parse(S[2]);
int[] T = new int[N];
S = Console.ReadLine().Split();
for (int i = 0; i < N; i++)
{
	T[i] = int.Parse(S[i]);
}
Array.Sort(T);
int R = 0;
for (int i = L; i < N - H; i++)
{
	R += T[i];
}

Console.WriteLine((double)R / (N - L - H));