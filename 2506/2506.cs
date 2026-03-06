#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int N = int.Parse(Console.ReadLine());
string[] S = Console.ReadLine().Split();
int R = 0;
int flg = 0;
for (int i = 0; i < N; i++)
{
	int t = int.Parse(S[i]);
	if (t == 0) flg = 0;
	else R += ++flg;
}

Console.WriteLine(R);